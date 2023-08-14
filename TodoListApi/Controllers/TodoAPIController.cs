using Microsoft.AspNetCore.Mvc;
using TodoListApi.Enum;
using TodoListApi.Models;
using TodoListApi.Repository;

namespace TodoListApi.Controllers
{
    [Route("api/todos")]
    [ApiController]
    public class TodoAPIController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public TodoAPIController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet(Name = "GetTodos")]
        public ActionResult<IEnumerable<Todo>> GetTodos()
        {
            return Ok(_unitOfWork.Todo.GetAll());
        }

        [HttpGet("{id:int}")]
        public ActionResult<Todo> GetTodo(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }

            var todo = _unitOfWork.Todo.Get(x => x.Id == id);

            if (todo == null)
            {
                return NotFound();
            }

            return Ok(todo);
        }

        [HttpPost]
        public ActionResult Create([FromBody] Todo todo)
        {
            if (todo == null)
            {
                return BadRequest(todo);
            }

            _unitOfWork.Todo.Add(todo);
            _unitOfWork.SaveChanges();

            return CreatedAtAction(nameof(GetTodos), new { id = todo.Id }, todo);
        }

        [HttpDelete("{id:int}")]
        public ActionResult Delete(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }

            var todo = _unitOfWork.Todo.Get(x => x.Id == id);
            if (todo == null)
            {
                return NotFound();
            }

            _unitOfWork.Todo.Remove(todo);
            _unitOfWork.SaveChanges();
            return NoContent();
        }

        [HttpPut("{id:int}")]
        public ActionResult Update(int id, Todo todo)
        {
            if (todo == null || id != todo.Id)
            {
                return BadRequest();
            }
            var todoFromDb = _unitOfWork.Todo.Get(x => x.Id == id);
            if (todoFromDb == null)
            {
                return NotFound();
            }

            todoFromDb.Title = todo.Title;
            todoFromDb.Description = todo.Description;

            _unitOfWork.Todo.Update(todoFromDb);
            _unitOfWork.SaveChanges();

            return NoContent();
        }


        [HttpPatch("{id:int}/status")]
        public IActionResult UpdateStatus(int id, Status newStatus)
        {
            var todo = _unitOfWork.Todo.Get(x => x.Id == id, tracked: true);
            if (todo == null)
            {
                return NotFound();
            }

            todo.Status = newStatus;
            _unitOfWork.SaveChanges();

            return NoContent();
        }
    }
}
