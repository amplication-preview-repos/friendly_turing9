using WomenSafetyService.APIs.Dtos;
using WomenSafetyService.Infrastructure.Models;

namespace WomenSafetyService.APIs.Extensions;

public static class EmergencyContactsExtensions
{
    public static EmergencyContact ToDto(this EmergencyContactDbModel model)
    {
        return new EmergencyContact
        {
            CreatedAt = model.CreatedAt,
            Id = model.Id,
            UpdatedAt = model.UpdatedAt,
        };
    }

    public static EmergencyContactDbModel ToModel(
        this EmergencyContactUpdateInput updateDto,
        EmergencyContactWhereUniqueInput uniqueId
    )
    {
        var emergencyContact = new EmergencyContactDbModel { Id = uniqueId.Id };

        if (updateDto.CreatedAt != null)
        {
            emergencyContact.CreatedAt = updateDto.CreatedAt.Value;
        }
        if (updateDto.UpdatedAt != null)
        {
            emergencyContact.UpdatedAt = updateDto.UpdatedAt.Value;
        }

        return emergencyContact;
    }
}
