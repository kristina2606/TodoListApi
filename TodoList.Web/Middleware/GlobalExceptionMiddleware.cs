using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Mvc;
using TodoList.Application.Exeptions;
using Microsoft.AspNetCore.Mvc.Controllers;

public class GlobalExceptionMiddleware
{
    private readonly RequestDelegate _next;

    public GlobalExceptionMiddleware(RequestDelegate next)
    {
        _next = next ?? throw new ArgumentNullException(nameof(next));
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
        var viewData = new ViewDataDictionary(new EmptyModelMetadataProvider(), new ModelStateDictionary())
        {
            ["ErrorMessage"] = ex.Message
        };

        var result = new ViewResult
        {
            ViewName = "ExceptionNotFound",
            ViewData = viewData
        };

        var actionContext = new ActionContext(context, context.GetRouteData(), new ControllerActionDescriptor());
        await result.ExecuteResultAsync(actionContext);
    }
}
