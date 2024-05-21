using Aerifloat.Api.Common.Middlewares.Filters.Swagger;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Aerifloat.Api.Common.ServiceRegisters;

public static class SwaggerGenServiceRegister
{
    public static void AddSwaggerGenService(this IServiceCollection services, string title, Version apiVersion, string? executingAssemblyFileName)
    {
        var envVal = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
        services.AddSwaggerGen(options =>
            {
                options.OperationFilter<AuthorizeAndParametersOperationFilter>();
                //options.OperationFilter<ParameterIgnoreFilter>();
                options.EnableAnnotations();
                options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = "다음과 같은 형식으로 JWT Authorization header에 토큰을 보내도록 합니다.<br /> \"Authorization: Bearer {token}\"",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.Http,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    Reference = new OpenApiReference
                    {
                        Type = ReferenceType.SecurityScheme,
                        Id = "Bearer",
                    },
                });

                var description = $"This Document is for Web Services on Aerifloat. Environment is \"<b>{envVal}</b>\"";

                options.SwaggerDoc($"v1", new OpenApiInfo
                {
                    Version = $"v{apiVersion}",
                    Title = $"Aerifloat {title} API",
                    Description = description,
                });

                options.SchemaFilter<EnumSchemaFilter>();
                if (!string.IsNullOrWhiteSpace(executingAssemblyFileName))
                {
                    var xmlFile = $"{executingAssemblyFileName}.xml";
                    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                    options.IncludeXmlComments(xmlPath, includeControllerXmlComments: true);
                }
            }
        );
    }

    private class EnumSchemaFilter : ISchemaFilter
    {
        public void Apply(OpenApiSchema model, SchemaFilterContext context)
        {
            if (context.Type.IsEnum)
            {
                string desc = "{";
                var enumStrings = new List<string>();
                Enum.GetNames(context.Type).ToList()
                    .ForEach(name => enumStrings.Add($"{Convert.ToInt64(Enum.Parse(context.Type, name))}:\"{name}\""));

                desc += string.Join(',', [.. enumStrings]);

                desc += "}";

                model.Description = desc;
            }
        }
    }
}
