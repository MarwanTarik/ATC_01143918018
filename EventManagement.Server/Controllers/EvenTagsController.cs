using EventManagement.Server.Dtos.EventTags;
using EventManagement.Server.Enums;
using EventManagement.Server.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EventManagement.Server.Controllers;

[Route("api/events/{eventId:int}/tags")]
[ApiController]
[Authorize(Policy = nameof(PoliciesEnum.RequireAnyRole))]
public class EvenTagsController(EventTagsService eventTagsService) : ControllerBase
{

    [HttpDelete]
    public async Task<IActionResult> DeleteEventTags(int eventId, [FromBody] IEnumerable<int> tagIds)
    {
         await eventTagsService.DeleteEventTagsAsync(eventId, tagIds);
        return NoContent();
    }
    
    [HttpGet]
    public async Task<IActionResult> GetEventTags(int eventId)
    {
        var tags = await eventTagsService.GetAllEventTagsAsync(eventId);
        return Ok(tags);
    }
    
    [HttpPost]
    public async Task<IActionResult> AddEventTags(int eventId, [FromBody] IEnumerable<AddEventTagDto> eventTags)
    {
        await eventTagsService.AddEventTagsAsync(eventId, eventTags);
        return CreatedAtAction(nameof(AddEventTags), eventTags);
    }
}
