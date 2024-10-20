using WomenSafetyService.Infrastructure;

namespace WomenSafetyService.APIs;

public class LocationsService : LocationsServiceBase
{
    public LocationsService(WomenSafetyServiceDbContext context)
        : base(context) { }
}
