using Microsoft.AspNetCore.Mvc;
using TodoList.Application.Models;
using TodoList.Application.Services;
using TodoList.Models;
using TodoList.Models.Enum;

namespace TodoList.Service.Controllers
{
    [Route("api/todos")]
    [ApiController]
    public class TodoController : ControllerBase
    {
        private readonly ITodoService _todoService;

        public TodoController(ITodoService todoService)
        {
            _todoService = todoService;
        }

        [HttpGet(Name = "GetTodos")]
        public ActionResult<IEnumerable<Todo>> GetTodos()
        {
            var todo = _todoService.GetTodos();
            return Ok(todo);
        }

        [HttpGet("{id:int}")]
        public ActionResult<Todo> GetTodo(int id)
        {
            var todo = _todoService.GetTodo(id);
            return Ok(todo);
        }

        [HttpPost]
        public ActionResult Create([FromBody] Todo todo)
        {
            if (todo == null)
            {
                return BadRequest();
            }

            var newTodoId = _todoService.Create(todo);

            return CreatedAtAction(nameof(GetTodo), new { id = newTodoId }, todo);
        }

        [HttpDelete("{id:int}")]
        public ActionResult Delete(int id)
        {
            _todoService.Delete(id);
            return NoContent();
        }

        [HttpPut("{id:int}")]
        public ActionResult Update(int id, UpdateTodoCommand todo)
        {
            if (todo == null || id != todo.Id)
            {
                return BadRequest();
            }
            _todoService.Update(todo);
            return NoContent();
        }


        [HttpPatch("{id:int}/status")]
        public IActionResult UpdateStatus(int id, Status newStatus)
        {
            _todoService.Update(id, newStatus);
            return NoContent();
        }
    }
}
