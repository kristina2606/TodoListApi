﻿using TodoList.Application.Exeptions;
using TodoList.Application.Models;
using TodoList.Application.Repositories;
using TodoList.Models;
using TodoList.Models.Enum;

namespace TodoList.Application.Services.Implementation
{
    public class TodoService : ITodoService
    {
        private readonly ITodoRepository _todoRepository;
        private readonly ICurrentUser _currentUser;

        public TodoService(ITodoRepository todoRepository, ICurrentUser currentUser)
        {
            _todoRepository = todoRepository;
            _currentUser = currentUser;
        }
        public async Task<int> CreateAsync(Todo todo)
        {
            ArgumentNullException.ThrowIfNull(todo);

            var newTodo = new Todo
            {
                Id = todo.Id,
                Title = todo.Title,
                Description = todo.Description,
                Status = todo.Status,
                UserId = _currentUser.Id,
                CreatedDate = DateTime.UtcNow
            };

            await _todoRepository.AddAsync(newTodo);
            return newTodo.Id;
        }

        public async Task DeleteAsync(int id)
        {
            var todo = await _todoRepository.GetAsync(id);
            if (todo == null || todo.UserId != _currentUser.Id)
            {
                throw new NotFoundException($"Todo with id {id} not found.");
            }

            await _todoRepository.RemoveAsync(todo);
        }

        public async Task<Todo> GetTodoAsync(int id)
        {
            var todo = await _todoRepository.GetAsync(id);
            if (todo == null || todo.UserId != _currentUser.Id)
            {
                throw new NotFoundException($"Todo with id {id} not found.");
            }

            return todo;
        }

        public async Task<IEnumerable<Todo>> GetTodosAsync()
        {
            return await _todoRepository.GetAllAsync(_currentUser.Id);
        }

        public async Task UpdateAsync(UpdateTodoCommand todo)
        {
            var todoFromDb = await _todoRepository.GetAsync(todo.Id);
            if (todo == null || todoFromDb.UserId != _currentUser.Id)
            {
                throw new NotFoundException($"Todo not found.");
            }

            todoFromDb.Title = todo.Title;
            todoFromDb.Description = todo.Description;

            await _todoRepository.UpdateAsync(todoFromDb);
        }

        public async Task UpdateAsync(int id, Status status)
        {
            var todo = await _todoRepository.GetAsync(id);
            if (todo == null || todo.UserId != _currentUser.Id)
            {
                throw new NotFoundException($"Todo with id {id} not found.");
            }

            todo.Status = status;

            await _todoRepository.UpdateAsync(todo);
        }
    }
}
