using Aerifloat.Api.Common.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace Aerifloat.Api.Common.Middlewares
{
    public class ExceptionHandlerMiddleware
    {
        private const string DefaultResponseContentType = "application/json";
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionHandlerMiddleware> _logger;

        public ExceptionHandlerMiddleware(RequestDelegate next, ILogger<ExceptionHandlerMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (OperationCanceledException ex)
            {
                await HandleCancel(httpContext, ex);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(httpContext, ex);
            }
        }

        async Task HandleCancel(HttpContext httpContext, Exception ex)
        {
            //Log.Canceled(_logger, httpContext.GetEndpoint()?.DisplayName);
            httpContext.Response.StatusCode = 409;
            await Task.CompletedTask;
        }

        async Task HandleExceptionAsync(HttpContext httpContext, Exception exception)
        {
            //httpContext.Response.ContentType = DefaultResponseContentType;
            //var response = exception switch
            //{
            //    ParamterException ex => ex.ErrorType == ErrorType.Parameter ? ParameterExceptionHandler(ex.ErrorCode, ex.ParamName) : ResultExceptionHandler(ex.ErrorCode, ex.ParamName),
            //    _ => new ApiErrorResponse<string>(ErrorCode.UnexpectedResult, exception.Message, "UnexpectedResult"),
            //};

            //await httpContext.Response.WriteAsJsonAsync(response);
            await Task.CompletedTask;
        }

        //private ApiErrorResponse<string> ParameterExceptionHandler(ErrorCode errorCode, string? paramName)
        //{
        //    Log.ParameterException(_logger, paramName ?? string.Empty);

        //    return new ApiErrorResponse<string>(errorCode, errorCode.ToString(), paramName);
        //}

        //private ApiErrorResponse<string> ResultExceptionHandler(ErrorCode errorCode, string? resultValueName)
        //{
        //    Log.ParameterException(_logger, resultValueName ?? string.Empty);
        //    return new ApiErrorResponse<string>(errorCode, errorCode.ToString(), resultValueName);
        //}
    }
}
