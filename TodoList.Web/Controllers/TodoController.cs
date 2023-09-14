using Microsoft.AspNetCore.Mvc;
using TodoList.Models.Enum;
using TodoList.Models;
using TodoList.Application.Services;
using TodoList.Application.Models;
using TodoList.Web.Models;

namespace Todo_List.Controllers
{
    public class TodoController : Controller
    {
        private readonly ITodoService _todoService;

        public TodoController(ITodoService todoService)
        {
            _todoService = todoService;
        }

        [HttpGet]
        public async Task<IActionResult> Index(Status? status)
        {
            var todosFromDb = await _todoService.GetTodosAsync(status);

            return View(todosFromDb);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View(new Todo());
        }

        [HttpPost]
        public async Task<IActionResult> Create(UpdateTodoCommand todo)
        {
            if (!ModelState.IsValid)
            {
                return View(todo);
            }

            await _todoService.CreateAsync(todo);
            TempData["success"] = "Task added successfully";

            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Update(int todoId)
        {
            if (todoId == 0)
            {
                return NotFound();
            }

            var todoFromDb = await _todoService.GetTodoAsync(todoId);
            if (todoFromDb == null)
            {
                return NotFound();
            }

            return View(todoFromDb);
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateTodoCommand todo)
        {
            if (!ModelState.IsValid)
            {
                return View(todo);
            }

            await _todoService.UpdateAsync(todo);
            TempData["success"] = "Task edited successfully";

            return Json(new { success = true });
        }

        [HttpPatch]
        public async Task<IActionResult> UpdateStatus([FromBody] UpdateStatusRequest request)
        {
            if (request.TodoId == 0)
            {
                return NotFound();
            }

            var todo = await _todoService.GetTodoAsync(request.TodoId);

            if (todo == null)
            {
                return NotFound();
            }

            if(Enum.TryParse(request.Status, out Status status))
            {
                await _todoService.UpdateAsync(request.TodoId, status);
                TempData["success"] = $"Task has been moved to '{request.Status}'.";

                return Json(new { success = true });

            }
                
            return Json(new { error = true });
        }


        [HttpDelete]
        public async Task<IActionResult> Delete(int todoId)
        {
            if (todoId == 0)
            {
                return NotFound();
            }

            await _todoService.DeleteAsync(todoId);
            TempData["success"] = "Task deleted successfully";

            return Json(new { success = true });
        }
    }
}
