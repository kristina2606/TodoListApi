using Microsoft.AspNetCore.Mvc;
using TodoList.Models.Enum;
using TodoList.Models;
using TodoList.Application.Services;
using TodoList.Application.Models;

namespace Todo_List.Controllers
{
    public class TodoController : Controller
    {
        private readonly ITodoService _todoService;

        public TodoController(ITodoService todoService)
        {
            _todoService = todoService;
        }
        public async Task<IActionResult> Index(string? status)
        {
            var todosFromDb = await _todoService.GetTodosAsync();

            if (!string.IsNullOrEmpty(status))
            {
                var taskStatus = Enum.Parse<Status>(status, ignoreCase: true);
                todosFromDb = todosFromDb.Where(x => x.Status == taskStatus);
            }
            else
            {
                todosFromDb = todosFromDb.Where(x => x.Status != Status.Completed);
            }

            return View(todosFromDb);
        }

        public async Task<IActionResult> Upsert(int todoId)
        {
            if (todoId == 0)
            {
                return View(new Todo());
            }

            var todoFromDb = await _todoService.GetTodoAsync(todoId);
            if (todoFromDb == null)
            {
                return NotFound();
            }

            return View(todoFromDb);
        }

        [HttpPost]
        public async Task<IActionResult> Upsert(UpdateTodoCommand todo)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }

            var message = todo.Id == 0 ? "Task added successfully" : "Task edited successfully";

            if (todo.Id == 0)
            {
                await _todoService.CreateAsync(todo);
            }
            else
            {
                await _todoService.UpdateAsync(todo);
            }

            TempData["success"] = message;
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> UpdateStatus(int todoId)
        {
            var message = "Task is already completed.";

            if (todoId == 0)
            {
                return NotFound();
            }

            var todo = await _todoService.GetTodoAsync(todoId);

            if (todo == null)
            {
                return NotFound();
            }

            Status nextStatus = Status.Completed;

            if (todo.Status == Status.Todo)
            {
                nextStatus = Status.InProgress;
                message = "Task has been moved to 'In Progress'.";
            }

            TempData["success"] = message;
            await _todoService.UpdateAsync(todoId, nextStatus);

            return RedirectToAction("Index");
        }

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
