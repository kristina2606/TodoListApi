﻿using Microsoft.AspNetCore.Mvc;
using TodoList.Application.Enums;
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

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Todo>>> GetTodosAsync()
        {
            var todo = await _todoService.GetTodosAsync(FilterStatus.All);
            return Ok(todo);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Todo>> GetTodoAsync(int id)
        {
            var todo = await _todoService.GetTodoAsync(id);
            return Ok(todo);
        }

        [HttpPost]
        public async Task<ActionResult> CreateAsync([FromBody] CreateTodoCommand todo)
        {
            if (string.IsNullOrEmpty(todo.Title))
            {
                return BadRequest();
            }

            var id = await _todoService.CreateAsync(todo);
            var createdTodo = await _todoService.GetTodoAsync(id);

            return Ok(createdTodo);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> DeleteAsync(int id)
        {
            await _todoService.DeleteAsync(id);
            return NoContent();
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> UpdateAsync(int id, UpdateTodoCommand todo)
        {
            if (todo == null || id != todo.Id)
            {
                return BadRequest();
            }

            await _todoService.UpdateAsync(todo);
            return NoContent();
        }

        [HttpPatch("{id:int}/status")]
        public async Task<IActionResult> UpdateStatusAsync(int id, Status newStatus)
        {
            await _todoService.UpdateAsync(id, newStatus);
            return NoContent();
        }
    }
}
