using Aerifloat.Api.Common.Configuration;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection;

namespace Opera.Infrastructure.Middlewares;

public static class JwtTokenServiceExtensions
{
    public static void AddJwtTokenServices(this IServiceCollection services, AppConfig appConfig)
    {
        var issuer = appConfig?.JwtValues?.Issuer;
        var secretKey = appConfig?.JwtValues?.SecretKey;
    
        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
        {
            //// Options
            //options.TokenValidationParameters = TokenHelper.GetTokenValidationParameters(issuer!, secretKey!);
            //options.RequireHttpsMetadata = false; // TODO: for DEV
            //options.SaveToken = true;
            //options.IncludeErrorDetails = true; // TODO: for DEV
            //// options.Authority = jwkUrl;
    
            //options.Events = new JwtBearerEvents
            //{
            //    OnChallenge = context =>
            //    {
            //        if (context.AuthenticateFailure != null && context.AuthenticateFailure.GetType() == typeof(SecurityTokenExpiredException))
            //        {
            //            context.Response.StatusCode = 419;
            //            context.HandleResponse();
            //        }
            //        return Task.CompletedTask;
            //    }
            //};
        });
    }
}