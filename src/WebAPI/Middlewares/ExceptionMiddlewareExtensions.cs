using Microsoft.AspNetCore.Authorization;

namespace WebAPI.Middlewares
{
    public static class ExceptionMiddlewareExtensions
    {
        public static IApplicationBuilder ConfigureCustomExceptionMiddleware(this IApplicationBuilder app)
        {
            if (app == null)
            {
                throw new ArgumentNullException(nameof(app));
            }
            return app.UseMiddleware<ExceptionMiddleware>();
        }
    }
}
