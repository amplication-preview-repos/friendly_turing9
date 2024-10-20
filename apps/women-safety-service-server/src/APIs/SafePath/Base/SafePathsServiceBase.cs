using Microsoft.EntityFrameworkCore;
using WomenSafetyService.APIs;
using WomenSafetyService.APIs.Common;
using WomenSafetyService.APIs.Dtos;
using WomenSafetyService.APIs.Errors;
using WomenSafetyService.APIs.Extensions;
using WomenSafetyService.Infrastructure;
using WomenSafetyService.Infrastructure.Models;

namespace WomenSafetyService.APIs;

public abstract class SafePathsServiceBase : ISafePathsService
{
    protected readonly WomenSafetyServiceDbContext _context;

    public SafePathsServiceBase(WomenSafetyServiceDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Create one SafePath
    /// </summary>
    public async Task<SafePath> CreateSafePath(SafePathCreateInput createDto)
    {
        var safePath = new SafePathDbModel
        {
            CreatedAt = createDto.CreatedAt,
            UpdatedAt = createDto.UpdatedAt
        };

        if (createDto.Id != null)
        {
            safePath.Id = createDto.Id;
        }

        _context.SafePaths.Add(safePath);
        await _context.SaveChangesAsync();

        var result = await _context.FindAsync<SafePathDbModel>(safePath.Id);

        if (result == null)
        {
            throw new NotFoundException();
        }

        return result.ToDto();
    }

    /// <summary>
    /// Delete one SafePath
    /// </summary>
    public async Task DeleteSafePath(SafePathWhereUniqueInput uniqueId)
    {
        var safePath = await _context.SafePaths.FindAsync(uniqueId.Id);
        if (safePath == null)
        {
            throw new NotFoundException();
        }

        _context.SafePaths.Remove(safePath);
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Find many SafePaths
    /// </summary>
    public async Task<List<SafePath>> SafePaths(SafePathFindManyArgs findManyArgs)
    {
        var safePaths = await _context
            .SafePaths.ApplyWhere(findManyArgs.Where)
            .ApplySkip(findManyArgs.Skip)
            .ApplyTake(findManyArgs.Take)
            .ApplyOrderBy(findManyArgs.SortBy)
            .ToListAsync();
        return safePaths.ConvertAll(safePath => safePath.ToDto());
    }

    /// <summary>
    /// Meta data about SafePath records
    /// </summary>
    public async Task<MetadataDto> SafePathsMeta(SafePathFindManyArgs findManyArgs)
    {
        var count = await _context.SafePaths.ApplyWhere(findManyArgs.Where).CountAsync();

        return new MetadataDto { Count = count };
    }

    /// <summary>
    /// Get one SafePath
    /// </summary>
    public async Task<SafePath> SafePath(SafePathWhereUniqueInput uniqueId)
    {
        var safePaths = await this.SafePaths(
            new SafePathFindManyArgs { Where = new SafePathWhereInput { Id = uniqueId.Id } }
        );
        var safePath = safePaths.FirstOrDefault();
        if (safePath == null)
        {
            throw new NotFoundException();
        }

        return safePath;
    }

    /// <summary>
    /// Update one SafePath
    /// </summary>
    public async Task UpdateSafePath(
        SafePathWhereUniqueInput uniqueId,
        SafePathUpdateInput updateDto
    )
    {
        var safePath = updateDto.ToModel(uniqueId);

        _context.Entry(safePath).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.SafePaths.Any(e => e.Id == safePath.Id))
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
