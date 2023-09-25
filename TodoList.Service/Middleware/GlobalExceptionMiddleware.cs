using Microsoft.AspNetCore.Mvc;
using TodoList.Application.Exceptions;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace TodoList.Service.Middleware
{
    public class GlobalExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public GlobalExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (NotFoundException ex)
            {
                await HandleException(context, ex);
            }
        }

        private async Task HandleException(HttpContext context, NotFoundException ex)
        {
            context.Response.StatusCode = StatusCodes.Status404NotFound;
            context.Response.ContentType = "application/json";

            var problemDetails = new ProblemDetails
            {
                Type = "about:blank",
                Title = "Todo not found",
                Status = StatusCodes.Status404NotFound,
                Detail = ex.Message,
                Instance = context.Request.Path
            };

            await context.Response.WriteAsync(JsonSerializer.Serialize(problemDetails));
        }
    }
}
