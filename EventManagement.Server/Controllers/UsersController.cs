using EventManagement.Server.Dtos.User;
using EventManagement.Server.Enums;
using EventManagement.Server.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EventManagement.Server.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize(Policy = nameof(PoliciesEnum.RequireAnyRole))]
public class UsersController(UsersService usersService) : ControllerBase
{
    [HttpGet("{id}")]
    public async Task<UserDto?> Get(string id)
    {
        return await usersService.GetUserByIdAsync(id);
    }

    [HttpPost]
    public async Task<UserDto> Post([FromBody] UserDto value)
    {
        return await usersService.AddUserAsync(value);
    }
    
    [HttpDelete("{id}")]
    public async Task Delete(string id)
    {
        await usersService.DeleteUserById(id);
    }
}

