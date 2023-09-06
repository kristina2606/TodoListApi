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

            switch (status)
            {
                case "Todo":
                    todosFromDb = todosFromDb.Where(x => x.Status == Status.Todo);
                    break;
                case "InProcess":
                    todosFromDb = todosFromDb.Where(x => x.Status == Status.InProgress);
                    break;
                case "Completed":
                    todosFromDb = todosFromDb.Where(x => x.Status == Status.Completed);
                    break;
                default:
                    todosFromDb = todosFromDb.Where(x => x.Status != Status.Completed);
                    break;
            }
            return View(todosFromDb);
        }

        public async Task<IActionResult> Upsert(int todoId)
        {
            var task = new Todo();

            if (todoId == 0)
            {
                return View(task);
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
            var message = "Task added successfully";

            if (ModelState.IsValid)
            {
                if (todo.Id == 0)
                {
                    await _todoService.CreateAsync(todo);
                }
                else
                {
                    await _todoService.UpdateAsync(todo);
                    message = "Task edited successfully";
                }

                TempData["success"] = message;

            }
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> UpdateStatus(int todoId, Status status)
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
            switch (todo.Status)
            {
                case Status.Todo:
                    nextStatus = Status.InProgress;
                    message = "Task has been moved to 'In Progress'.";
                    break;
                case Status.InProgress:
                    message = "Task has been moved to 'Completed'.";
                    break;
                case Status.Completed:
                    break;
                default:
                    TempData["error"] = "Invalid task status.";
                    return RedirectToAction("Index");
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
