using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using TodoList.Application;
using TodoList.Application.Exeptions;

public class CurrentUserProvider : ICurrentUser
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    public CurrentUserProvider(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    public string Id
    {
        get
        {
            var userId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (userId != null)
            {
                return userId;
            }

            throw new NotFoundException("User ID is missing or user is not logged in.");
        }
    }

    public string Name
    {
        get
        {
            return _httpContextAccessor.HttpContext.User.Identity.Name;
        }
    }

    public string Email
    {
        get
        {
            return _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.Email)?.Value;
        }
    }
}
