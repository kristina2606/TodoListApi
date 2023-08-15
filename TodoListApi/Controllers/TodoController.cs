using Microsoft.AspNetCore.Mvc;
using TodoListApi.Application.Exeptions;
using TodoListApi.Application.Services;
using TodoListApi.Enum;
using TodoListApi.Models;

namespace TodoListApi.Controllers
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
            try
            {
                var todo = _todoService.GetTodo(id);
                return Ok(todo);
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
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
            try
            {
                _todoService.Delete(id);
                return NoContent();
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPut("{id:int}")]
        public ActionResult Update(int id, Todo todo)
        {
            if (todo == null || id != todo.Id)
            {
                return BadRequest();
            }
            try
            {
                var todoFromDb = _todoService.GetTodo(id);
                todoFromDb.Title = todo.Title;
                todoFromDb.Description = todo.Description;
                _todoService.Update(todoFromDb.Id);
                return NoContent();
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }


        [HttpPatch("{id:int}/status")]
        public IActionResult UpdateStatus(int id, Status newStatus)
        {
            try
            {
                var todo = _todoService.GetTodo(id);
                todo.Status = newStatus;
                _todoService.Update(todo.Id);
                return NoContent();
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
