using EventManagement.Server.Dtos.Event;
using EventManagement.Server.Dtos.User;
using EventManagement.Server.Enums;
using EventManagement.Server.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EventManagement.Server.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize(Policy = nameof(PoliciesEnum.RequireAdminRole))]
public class EventsController(EventsService eventsService) : ControllerBase
{
    private new UserDto User => (UserDto)HttpContext.Items["user"]!;      
    
    [HttpGet]
    public async Task<IActionResult> GetAllEvents()
    {
        var events = await eventsService.GetAllEventsAsync();
        return Ok(events);
    }

    [HttpGet("{eventId:int}")]
    public async Task<IActionResult> GetEventById(int eventId)
    {
        var eventDetails = await eventsService.GetEventByIdAsync(eventId);
        if (eventDetails == null)
        {
            return NotFound();
        }

        return Ok(eventDetails);
    }
    
    [HttpGet("user/{userId}")]
    public async Task<IActionResult> GetEventsByUserId(string userId)
    {
        var events = await eventsService.GetEventsByUserIdAsync(userId);
        return Ok(events);
    }
    
    [HttpPost]
    public async Task<IActionResult> AddEvent([FromBody] AddEventDto eventDto)
    {
        await eventsService.AddEventAsync(eventDto, User.Id);
        return CreatedAtAction(nameof(AddEvent), eventDto);
    }
    [HttpPut("{eventId:int}")]
    public async Task<IActionResult> UpdateEvent(int eventId, [FromBody] UpdateEventDto eventDto)
    {
        await eventsService.UpdateEventAsync(eventId, eventDto, User.Id);
        return NoContent();
    }
    
    [HttpDelete("{eventId:int}")]
    public async Task<IActionResult> DeleteEvent(int eventId)
    {
        await eventsService.DeleteEventAsync(eventId, User.Id);
        return NoContent();
    }
}
