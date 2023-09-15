using Microsoft.AspNetCore.Mvc;
using TodoList.Models.Enum;
using TodoList.Application.Services;
using TodoList.Application.Models;
using TodoList.Web.Models;
using TodoList.Web.Models.Enum;

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
        public async Task<IActionResult> Index(FilterStatus status = FilterStatus.Active)
        {
            var todosFromDb = await _todoService.GetTodosAsync(status);

            return View(todosFromDb);
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

            var todoFromDb = await _todoService.GetTodoAsync(todoId);
            if (todoFromDb == null)
            {
                return NotFound();
            }

            var todoVM = new TodoDetailedViewModel
            {
                Id = todoFromDb.Id,
                Title = todoFromDb.Title,
                Description = todoFromDb.Description
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

            var todo = await _todoService.GetTodoAsync(request.TodoId);

            if (todo == null)
            {
                return NotFound();
            }

            if(Enum.TryParse(request.Status, out Status status))
            {
                await _todoService.UpdateAsync(request.TodoId, status);
                TempData["success"] = $"Task has been moved to '{request.Status}'.";

                return RedirectToAction("Index");
            }

            return NotFound();
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
