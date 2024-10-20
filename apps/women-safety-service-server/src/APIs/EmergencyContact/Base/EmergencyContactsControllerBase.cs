using Microsoft.AspNetCore.Mvc;
using WomenSafetyService.APIs;
using WomenSafetyService.APIs.Common;
using WomenSafetyService.APIs.Dtos;
using WomenSafetyService.APIs.Errors;

namespace WomenSafetyService.APIs;

[Route("api/[controller]")]
[ApiController()]
public abstract class EmergencyContactsControllerBase : ControllerBase
{
    protected readonly IEmergencyContactsService _service;

    public EmergencyContactsControllerBase(IEmergencyContactsService service)
    {
        _service = service;
    }

    /// <summary>
    /// Create one EmergencyContact
    /// </summary>
    [HttpPost()]
    public async Task<ActionResult<EmergencyContact>> CreateEmergencyContact(
        EmergencyContactCreateInput input
    )
    {
        var emergencyContact = await _service.CreateEmergencyContact(input);

        return CreatedAtAction(
            nameof(EmergencyContact),
            new { id = emergencyContact.Id },
            emergencyContact
        );
    }

    /// <summary>
    /// Delete one EmergencyContact
    /// </summary>
    [HttpDelete("{Id}")]
    public async Task<ActionResult> DeleteEmergencyContact(
        [FromRoute()] EmergencyContactWhereUniqueInput uniqueId
    )
    {
        try
        {
            await _service.DeleteEmergencyContact(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Find many EmergencyContacts
    /// </summary>
    [HttpGet()]
    public async Task<ActionResult<List<EmergencyContact>>> EmergencyContacts(
        [FromQuery()] EmergencyContactFindManyArgs filter
    )
    {
        return Ok(await _service.EmergencyContacts(filter));
    }

    /// <summary>
    /// Meta data about EmergencyContact records
    /// </summary>
    [HttpPost("meta")]
    public async Task<ActionResult<MetadataDto>> EmergencyContactsMeta(
        [FromQuery()] EmergencyContactFindManyArgs filter
    )
    {
        return Ok(await _service.EmergencyContactsMeta(filter));
    }

    /// <summary>
    /// Get one EmergencyContact
    /// </summary>
    [HttpGet("{Id}")]
    public async Task<ActionResult<EmergencyContact>> EmergencyContact(
        [FromRoute()] EmergencyContactWhereUniqueInput uniqueId
    )
    {
        try
        {
            return await _service.EmergencyContact(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }

    /// <summary>
    /// Update one EmergencyContact
    /// </summary>
    [HttpPatch("{Id}")]
    public async Task<ActionResult> UpdateEmergencyContact(
        [FromRoute()] EmergencyContactWhereUniqueInput uniqueId,
        [FromQuery()] EmergencyContactUpdateInput emergencyContactUpdateDto
    )
    {
        try
        {
            await _service.UpdateEmergencyContact(uniqueId, emergencyContactUpdateDto);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }
}
