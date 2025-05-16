using EventManagement.Server.Enums;
using EventManagement.Server.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EventManagement.Server.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize(Policy = nameof(PoliciesEnum.RequireAnyRole))]
public class TagsController(TagsService tagsService) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAllTags()
    {
        var tags = await tagsService.GetAllTagsAsync();
        return Ok(tags);
    }

    [HttpGet("{tagId:int}")]
    public async Task<IActionResult> GetTagById(int tagId)
    {
        var tag = await tagsService.GetTagByIdAsync(tagId);
        if (tag == null)
        {
            return NotFound();
        }

        return Ok(tag);
    }
}
