using WomenSafetyService.APIs.Dtos;
using WomenSafetyService.Infrastructure.Models;

namespace WomenSafetyService.APIs.Extensions;

public static class SafePathsExtensions
{
    public static SafePath ToDto(this SafePathDbModel model)
    {
        return new SafePath
        {
            CreatedAt = model.CreatedAt,
            Id = model.Id,
            UpdatedAt = model.UpdatedAt,
        };
    }

    public static SafePathDbModel ToModel(
        this SafePathUpdateInput updateDto,
        SafePathWhereUniqueInput uniqueId
    )
    {
        var safePath = new SafePathDbModel { Id = uniqueId.Id };

        if (updateDto.CreatedAt != null)
        {
            safePath.CreatedAt = updateDto.CreatedAt.Value;
        }
        if (updateDto.UpdatedAt != null)
        {
            safePath.UpdatedAt = updateDto.UpdatedAt.Value;
        }

        return safePath;
    }
}
