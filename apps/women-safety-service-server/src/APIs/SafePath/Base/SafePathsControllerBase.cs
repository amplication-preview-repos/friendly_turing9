using Microsoft.AspNetCore.Mvc;
using WomenSafetyService.APIs;
using WomenSafetyService.APIs.Common;
using WomenSafetyService.APIs.Dtos;
using WomenSafetyService.APIs.Errors;

namespace WomenSafetyService.APIs;

[Route("api/[controller]")]
[ApiController()]
public abstract class SafePathsControllerBase : ControllerBase
{
    protected readonly ISafePathsService _service;

    public SafePathsControllerBase(ISafePathsService service)
    {
        _service = service;
    }

    /// <summary>
    /// Create one SafePath
    /// </summary>
    [HttpPost()]
    public async Task<ActionResult<SafePath>> CreateSafePath(SafePathCreateInput input)
    {
        var safePath = await _service.CreateSafePath(input);

        return CreatedAtAction(nameof(SafePath), new { id = safePath.Id }, safePath);
    }

    /// <summary>
    /// Delete one SafePath
    /// </summary>
    [HttpDelete("{Id}")]
    public async Task<ActionResult> DeleteSafePath([FromRoute()] SafePathWhereUniqueInput uniqueId)
    {
        try
        {
            await _service.DeleteSafePath(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Find many SafePaths
    /// </summary>
    [HttpGet()]
    public async Task<ActionResult<List<SafePath>>> SafePaths(
        [FromQuery()] SafePathFindManyArgs filter
    )
    {
        return Ok(await _service.SafePaths(filter));
    }

    /// <summary>
    /// Meta data about SafePath records
    /// </summary>
    [HttpPost("meta")]
    public async Task<ActionResult<MetadataDto>> SafePathsMeta(
        [FromQuery()] SafePathFindManyArgs filter
    )
    {
        return Ok(await _service.SafePathsMeta(filter));
    }

    /// <summary>
    /// Get one SafePath
    /// </summary>
    [HttpGet("{Id}")]
    public async Task<ActionResult<SafePath>> SafePath(
        [FromRoute()] SafePathWhereUniqueInput uniqueId
    )
    {
        try
        {
            return await _service.SafePath(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }

    /// <summary>
    /// Update one SafePath
    /// </summary>
    [HttpPatch("{Id}")]
    public async Task<ActionResult> UpdateSafePath(
        [FromRoute()] SafePathWhereUniqueInput uniqueId,
        [FromQuery()] SafePathUpdateInput safePathUpdateDto
    )
    {
        try
        {
            await _service.UpdateSafePath(uniqueId, safePathUpdateDto);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }
}
