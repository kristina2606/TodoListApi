using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using TodoList.Application.Exeptions;

namespace TodoList.Application.Exceptions
{
    public class GlobalExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            if (context.Exception is NotFoundException notFoundException)
            {
                context.Result = new NotFoundObjectResult(new ProblemDetails
                {
                    Type = "https://support.microsoft.com/en-gb/topic/-http-404-error-when-you-access-a-website-with-url-redirection-in-windows-d443a664-3e54-c4c8-c71c-8743288e29b1",
                    Title = "Todo not found",
                    Status = 404,
                    Detail = notFoundException.Message,
                    Instance = context.HttpContext.Request.Path
                });

                context.ExceptionHandled = true;
            }
        }
    }
}
