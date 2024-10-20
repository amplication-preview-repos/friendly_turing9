using WomenSafetyService.APIs.Dtos;
using WomenSafetyService.Infrastructure.Models;

namespace WomenSafetyService.APIs.Extensions;

public static class LocationsExtensions
{
    public static Location ToDto(this LocationDbModel model)
    {
        return new Location
        {
            CreatedAt = model.CreatedAt,
            Id = model.Id,
            UpdatedAt = model.UpdatedAt,
        };
    }

    public static LocationDbModel ToModel(
        this LocationUpdateInput updateDto,
        LocationWhereUniqueInput uniqueId
    )
    {
        var location = new LocationDbModel { Id = uniqueId.Id };

        if (updateDto.CreatedAt != null)
        {
            location.CreatedAt = updateDto.CreatedAt.Value;
        }
        if (updateDto.UpdatedAt != null)
        {
            location.UpdatedAt = updateDto.UpdatedAt.Value;
        }

        return location;
    }
}
