using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System.Security.Claims;
using TodoList.Application;

namespace TodoList.Persistence
{
    public class CurrentUserProvider : ICurrentUser
    {
        public string? Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;

        public static CurrentUserProvider? Resolve(IServiceProvider sp)
        {
            var httpContext = sp.GetRequiredService<IHttpContextAccessor>().HttpContext;
            var userId = httpContext?.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (userId == null)
            {
                return new CurrentUserProvider(); 
            }


            return new CurrentUserProvider
            {
                Id = userId,
                Name = httpContext.User?.Identity.Name ?? string.Empty,
                Email = httpContext.User?.FindFirst(ClaimTypes.Email)?.Value ?? string.Empty,
            };
        }
    }
}
