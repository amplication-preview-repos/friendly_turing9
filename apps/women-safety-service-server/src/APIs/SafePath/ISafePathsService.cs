using WomenSafetyService.APIs.Common;
using WomenSafetyService.APIs.Dtos;

namespace WomenSafetyService.APIs;

public interface ISafePathsService
{
    /// <summary>
    /// Create one SafePath
    /// </summary>
    public Task<SafePath> CreateSafePath(SafePathCreateInput safepath);

    /// <summary>
    /// Delete one SafePath
    /// </summary>
    public Task DeleteSafePath(SafePathWhereUniqueInput uniqueId);

    /// <summary>
    /// Find many SafePaths
    /// </summary>
    public Task<List<SafePath>> SafePaths(SafePathFindManyArgs findManyArgs);

    /// <summary>
    /// Meta data about SafePath records
    /// </summary>
    public Task<MetadataDto> SafePathsMeta(SafePathFindManyArgs findManyArgs);

    /// <summary>
    /// Get one SafePath
    /// </summary>
    public Task<SafePath> SafePath(SafePathWhereUniqueInput uniqueId);

    /// <summary>
    /// Update one SafePath
    /// </summary>
    public Task UpdateSafePath(SafePathWhereUniqueInput uniqueId, SafePathUpdateInput updateDto);
}
