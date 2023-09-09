using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using TodoList.Application;

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

            return string.Empty;
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
