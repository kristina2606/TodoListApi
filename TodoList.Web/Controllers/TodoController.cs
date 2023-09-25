using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TodoList.Application.Services;
using TodoList.Application.Models;
using TodoList.Web.Models;
using TodoList.Application.Enums;
using TodoList.Application.Extensions;

namespace TodoList.Web.Controllers
{
    [Authorize]
    public class TodoController : Controller
    {
        private readonly ITodoService _todoService;

        public TodoController(ITodoService todoService)
        {
            _todoService = todoService;
        }
       
        [HttpGet]
        public async Task<IActionResult> Index(FilterStatus status)
        {
            var todo = await _todoService.GetTodosAsync(status);

            return View(todo);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View(new CreateTodoCommand());
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateTodoCommand todo)
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

            var todo = await _todoService.GetTodoAsync(todoId);

            var todoVM = new TodoDetailedViewModel
            {
                Id = todo.Id,
                Title = todo.Title,
                Description = todo.Description
            };

            return View(todoVM);
        }

        [HttpPost]
        public async Task<IActionResult> Update(TodoDetailedViewModel todoVM)
        {
            if (!ModelState.IsValid)
            {
                return View(todoVM);
            }

            var todo = new UpdateTodoCommand
            {
                Id = todoVM.Id,
                Title = todoVM.Title,
                Description = todoVM.Description
            };

            await _todoService.UpdateAsync(todo);
            TempData["success"] = "Task edited successfully";

            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> UpdateStatus(UpdateStatusRequest request)
        {
            if (request.TodoId == 0)
            {
                return NotFound();
            }

            await _todoService.UpdateAsync(request.TodoId, request.Status);
            TempData["success"] = $"Task has been moved to '{request.Status.ToDisplayName()}'.";

            return RedirectToAction("Index");
        }


        [HttpPost]
        public async Task<IActionResult> Delete(int todoId)
        {
            if (todoId == 0)
            {
                return NotFound();
            }

            await _todoService.DeleteAsync(todoId);
            TempData["success"] = "Task deleted successfully";

            return RedirectToAction("Index");
        }
    }
}
