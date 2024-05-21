﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Reflection;

namespace Aerifloat.Api.Common.Middlewares.Filters.Swagger;

public class AuthorizeAndParametersOperationFilter : IOperationFilter
{
    public void Apply(OpenApiOperation operation, OperationFilterContext context)
    {
        operation.Description = operation.Deprecated ? context.MethodInfo.GetCustomAttribute<ObsoleteAttribute>()?.Message : operation.Description;
        context.ApiDescription.TryGetMethodInfo(out var methodInfo);

        if (methodInfo == null)
        {
            return;
        }

        var hasAuthorizeAttribute = false;

        if (methodInfo.MemberType == MemberTypes.Method)
        {
            // NOTE: Check the controller itself has Authorize attribute
            hasAuthorizeAttribute = methodInfo.DeclaringType == null ? false
                : methodInfo.DeclaringType.GetCustomAttributes(true).OfType<TypeFilterAttribute>().Any()
                || methodInfo.DeclaringType.GetCustomAttributes(true).OfType<AuthorizeAttribute>().Any();

            // NOTE: Controller has Authorize attribute, so check the endpoint itself.
            //       Take into account the allow anonymous attribute
            if (hasAuthorizeAttribute)
            {
                hasAuthorizeAttribute = !methodInfo.GetCustomAttributes(true).OfType<AllowAnonymousAttribute>().Any();
            }
            else
            {
                //hasAuthorizeAttribute = methodInfo.GetCustomAttributes(true).OfType<AuthorizeAttribute>().Any();
                hasAuthorizeAttribute = methodInfo.GetCustomAttributes(true).OfType<TypeFilterAttribute>().Any()
                    || methodInfo.GetCustomAttributes(true).OfType<AuthorizeAttribute>().Any();
            }
        }

        if (!hasAuthorizeAttribute)
        {
            return;
        }

        // NOTE: This adds the "Padlock" icon to the endpoint in swagger,
        //       we can also pass through the names of the policies in the string[]
        //       which will indicate which permission you require.
        if (operation.Security == null)
        {
            operation.Security = [];
        }

        var scheme = new OpenApiSecurityScheme { Reference = new OpenApiReference { Type = ReferenceType.SecurityScheme, Id = "Bearer" } };
        operation.Security.Add(new OpenApiSecurityRequirement
        {
            [scheme] = new List<string>()
        });
    }
}
