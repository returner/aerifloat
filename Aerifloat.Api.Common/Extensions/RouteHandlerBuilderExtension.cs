using Aerifloat.Api.Common.Responses;
using Aerifloat.Api.Common.TypeDefines;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Swashbuckle.AspNetCore.Annotations;

namespace Aerifloat.Api.Common.Extensions;

public static class RouteHandlerBuilderExtension
{
    public static RouteHandlerBuilder SuccessResponse<T>(this RouteHandlerBuilder builder)
    {
        return builder.Produces<SuccessResponse<T>>();
    }

    public static RouteHandlerBuilder PaginationResponse<T>(this RouteHandlerBuilder builder)
    {
        return builder.Produces<PaginationResponse<T>>();
    }

    public static RouteHandlerBuilder SwaggerMessage(this RouteHandlerBuilder builder, SwaggerMessageType swaggerMessageType, string summary)
    {
        return builder.WithMetadata(new SwaggerOperationAttribute($"[{swaggerMessageType}] {summary}"));
    }

    public static RouteHandlerBuilder SwaggerMessage(this RouteHandlerBuilder builder, SwaggerMessageType swaggerMessageType, string summary, string description)
    {
        return builder.WithMetadata(new SwaggerOperationAttribute($"[{swaggerMessageType}] {summary}", description));
    }
}
