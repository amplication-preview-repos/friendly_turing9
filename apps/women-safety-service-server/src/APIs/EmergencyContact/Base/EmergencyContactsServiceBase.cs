using Microsoft.EntityFrameworkCore;
using WomenSafetyService.APIs;
using WomenSafetyService.APIs.Common;
using WomenSafetyService.APIs.Dtos;
using WomenSafetyService.APIs.Errors;
using WomenSafetyService.APIs.Extensions;
using WomenSafetyService.Infrastructure;
using WomenSafetyService.Infrastructure.Models;

namespace WomenSafetyService.APIs;

public abstract class EmergencyContactsServiceBase : IEmergencyContactsService
{
    protected readonly WomenSafetyServiceDbContext _context;

    public EmergencyContactsServiceBase(WomenSafetyServiceDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Create one EmergencyContact
    /// </summary>
    public async Task<EmergencyContact> CreateEmergencyContact(
        EmergencyContactCreateInput createDto
    )
    {
        var emergencyContact = new EmergencyContactDbModel
        {
            CreatedAt = createDto.CreatedAt,
            UpdatedAt = createDto.UpdatedAt
        };

        if (createDto.Id != null)
        {
            emergencyContact.Id = createDto.Id;
        }

        _context.EmergencyContacts.Add(emergencyContact);
        await _context.SaveChangesAsync();

        var result = await _context.FindAsync<EmergencyContactDbModel>(emergencyContact.Id);

        if (result == null)
        {
            throw new NotFoundException();
        }

        return result.ToDto();
    }

    /// <summary>
    /// Delete one EmergencyContact
    /// </summary>
    public async Task DeleteEmergencyContact(EmergencyContactWhereUniqueInput uniqueId)
    {
        var emergencyContact = await _context.EmergencyContacts.FindAsync(uniqueId.Id);
        if (emergencyContact == null)
        {
            throw new NotFoundException();
        }

        _context.EmergencyContacts.Remove(emergencyContact);
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Find many EmergencyContacts
    /// </summary>
    public async Task<List<EmergencyContact>> EmergencyContacts(
        EmergencyContactFindManyArgs findManyArgs
    )
    {
        var emergencyContacts = await _context
            .EmergencyContacts.ApplyWhere(findManyArgs.Where)
            .ApplySkip(findManyArgs.Skip)
            .ApplyTake(findManyArgs.Take)
            .ApplyOrderBy(findManyArgs.SortBy)
            .ToListAsync();
        return emergencyContacts.ConvertAll(emergencyContact => emergencyContact.ToDto());
    }

    /// <summary>
    /// Meta data about EmergencyContact records
    /// </summary>
    public async Task<MetadataDto> EmergencyContactsMeta(EmergencyContactFindManyArgs findManyArgs)
    {
        var count = await _context.EmergencyContacts.ApplyWhere(findManyArgs.Where).CountAsync();

        return new MetadataDto { Count = count };
    }

    /// <summary>
    /// Get one EmergencyContact
    /// </summary>
    public async Task<EmergencyContact> EmergencyContact(EmergencyContactWhereUniqueInput uniqueId)
    {
        var emergencyContacts = await this.EmergencyContacts(
            new EmergencyContactFindManyArgs
            {
                Where = new EmergencyContactWhereInput { Id = uniqueId.Id }
            }
        );
        var emergencyContact = emergencyContacts.FirstOrDefault();
        if (emergencyContact == null)
        {
            throw new NotFoundException();
        }

        return emergencyContact;
    }

    /// <summary>
    /// Update one EmergencyContact
    /// </summary>
    public async Task UpdateEmergencyContact(
        EmergencyContactWhereUniqueInput uniqueId,
        EmergencyContactUpdateInput updateDto
    )
    {
        var emergencyContact = updateDto.ToModel(uniqueId);

        _context.Entry(emergencyContact).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.EmergencyContacts.Any(e => e.Id == emergencyContact.Id))
            {
                throw new NotFoundException();
            }
            else
            {
                throw;
            }
        }
    }
}
