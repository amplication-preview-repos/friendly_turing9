using WomenSafetyService.Infrastructure;

namespace WomenSafetyService.APIs;

public class SafePathsService : SafePathsServiceBase
{
    public SafePathsService(WomenSafetyServiceDbContext context)
        : base(context) { }
}
