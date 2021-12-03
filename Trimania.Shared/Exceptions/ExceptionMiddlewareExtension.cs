using Microsoft.AspNetCore.Builder;

namespace Trimania.Shared.Exceptions
{
    public static class ExceptionMiddlewareExtension
    {
        public static IApplicationBuilder ConfigureCustomExceptionMiddleware(this IApplicationBuilder app)
        {
            return app.UseMiddleware<CustomExceptionMiddleware>();
        }
    }
}