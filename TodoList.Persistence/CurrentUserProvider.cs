using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using TodoList.Application;
using TodoList.Application.Exceptions;
using TodoList.Models;

namespace TodoList.Persistence
{
    public class CurrentUserProvider : ICurrentUser
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CurrentUserProvider(IHttpContextAccessor httpContextAccessor)
        {
            Id = httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value
                    ?? throw new NullReferenceException("User ID is missing or user is not logged in.");

            Name = httpContextAccessor.HttpContext.User.Identity.Name;
            Email = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.Email)?.Value;
        }

        public string Id { get; private set; }
        public string Name { get; private set; }
        public string Email { get; private set; }
    }
}
