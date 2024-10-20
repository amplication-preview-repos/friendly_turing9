using WomenSafetyService.APIs.Common;
using WomenSafetyService.APIs.Dtos;

namespace WomenSafetyService.APIs;

public interface IEmergencyContactsService
{
    /// <summary>
    /// Create one EmergencyContact
    /// </summary>
    public Task<EmergencyContact> CreateEmergencyContact(
        EmergencyContactCreateInput emergencycontact
    );

    /// <summary>
    /// Delete one EmergencyContact
    /// </summary>
    public Task DeleteEmergencyContact(EmergencyContactWhereUniqueInput uniqueId);

    /// <summary>
    /// Find many EmergencyContacts
    /// </summary>
    public Task<List<EmergencyContact>> EmergencyContacts(
        EmergencyContactFindManyArgs findManyArgs
    );

    /// <summary>
    /// Meta data about EmergencyContact records
    /// </summary>
    public Task<MetadataDto> EmergencyContactsMeta(EmergencyContactFindManyArgs findManyArgs);

    /// <summary>
    /// Get one EmergencyContact
    /// </summary>
    public Task<EmergencyContact> EmergencyContact(EmergencyContactWhereUniqueInput uniqueId);

    /// <summary>
    /// Update one EmergencyContact
    /// </summary>
    public Task UpdateEmergencyContact(
        EmergencyContactWhereUniqueInput uniqueId,
        EmergencyContactUpdateInput updateDto
    );
}
