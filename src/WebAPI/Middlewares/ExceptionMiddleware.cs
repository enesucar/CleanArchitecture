using Application.Common.Exceptions;
using Application.Common.Extensions;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Middlewares
{
    public class ExceptionMiddleware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            }
            catch (Exception exception)
            {
                await HandleExceptionAsync(context, exception);
            }
        }

        private async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";

            if (exception.GetType() == typeof(NotFoundException)) await CreateNotFoundException(context, exception);
            if (exception.GetType() == typeof(ValidationException)) await CreateValidationException(context, exception);
        }

        private async Task CreateNotFoundException(HttpContext context, Exception exception)
        {
            var details = new ProblemDetails()
            {
                Type = "https://tools.ietf.org/html/rfc7231#section-6.5.4",
                Title = "Not found exception",
                Detail = exception.Message,
                Instance = context.Request.Path,
                Status = StatusCodes.Status404NotFound
            };
            context.Response.StatusCode = StatusCodes.Status404NotFound;
            await context.Response.WriteAsJsonAsync(details);
        }

        private async Task CreateValidationException(HttpContext context, Exception exception)
        {
            var validationException = (ValidationException)exception;
            var errors = validationException.Errors.ToDictionary();
            var details = new ValidationProblemDetails(errors)
            {
                Type = "https://tools.ietf.org/html/rfc7231#section-6.5.1",
                Title = "Validation exception",
                Detail = exception.Message,
                Instance = context.Request.Path,
                Status = StatusCodes.Status400BadRequest 
            };
            context.Response.StatusCode = StatusCodes.Status404NotFound;
            await context.Response.WriteAsJsonAsync(details);
        }
    }
}
