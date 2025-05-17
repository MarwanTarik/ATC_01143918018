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
    public async Task<IActionResult> Get(string id)
    {
        var user = await usersService.GetUserByIdAsync(id);
        if (user == null)
        {
            return NotFound();
        }
        return Ok(user);
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] UserDto value)
    {
         var user = await usersService.AddUserAsync(value);
        return CreatedAtAction(nameof(Post), user);
    }
}

