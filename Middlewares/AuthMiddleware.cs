using EventManagement.Server.Dtos.User;
using EventManagement.Server.Enums;

namespace EventManagement.Server.Middlewares;

public class AuthMiddleware(RequestDelegate next)
{
    public async Task InvokeAsync(HttpContext context)
    {
        var path = context.Request.Path;
        
        if (path.StartsWithSegments("/swagger") 
            || path.StartsWithSegments("/openapi")
            || path.StartsWithSegments("/scalar"))
        {
            await next(context);
            return;
        }
        
        
        var roleString = context.User.FindFirst("http://localhost:5105/roles")?.Value;
        var isParsed = Enum.TryParse<Role>(roleString, true, out var roleEnum);
        var sub = context.User.Identity?.Name;
        
        if (string.IsNullOrEmpty(sub) 
            || !isParsed)
        {
            context.Response.StatusCode = StatusCodes.Status401Unauthorized;
            return;
        }
        
        var user = new UserDto(
            Id: sub,
            Role: roleEnum);
        
        context.Items["user"] = user;
        
        await next(context);
    }
}