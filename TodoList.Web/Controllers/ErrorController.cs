using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace TodoList.Web.Controllers
{
    public class ErrorController : Controller
    {
        public ErrorController()
        {
        }
        public IActionResult Index()
        {
            var exceptionHandlerFeature = HttpContext.Features.Get<IExceptionHandlerFeature>();
            var error = exceptionHandlerFeature?.Error;

            return View(error);
        }
    }
}
