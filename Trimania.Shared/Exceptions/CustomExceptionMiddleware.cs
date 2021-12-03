using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Trimania.Shared.Api;

namespace Trimania.Shared.Exceptions
{
    public class CustomExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public CustomExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                // await _next.Invoke(context).ConfigureAwait(false);
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex).ConfigureAwait(false);
            }
        }

        private static HttpStatusCode GetErrorCode(Exception e)
        {
            switch (e)
            {
                case BusinessRuleException _:
                    return HttpStatusCode.Conflict;
                default:
                    return HttpStatusCode.InternalServerError;
            }
        }

        private async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            var response = context.Response;

            var statusCode = 0;

            if (exception != null)
            {
                statusCode = (int)GetErrorCode(exception);
            }

            var message = exception != null && !string.IsNullOrWhiteSpace(exception?.Message) ? exception.Message : "Unexpected error";

            response.ContentType = "application/json";
            response.StatusCode = statusCode;

            var data = new CustomResponse<object>();
            data.SetError(message);

            await response.WriteAsync(JsonSerializer.Serialize(data, data.GetType(), new JsonSerializerOptions()
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            })).ConfigureAwait(false);
        }

    }
}
