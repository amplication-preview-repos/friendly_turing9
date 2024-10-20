using Microsoft.AspNetCore.Mvc;

namespace WomenSafetyService.APIs;

[ApiController()]
public class LocationsController : LocationsControllerBase
{
    public LocationsController(ILocationsService service)
        : base(service) { }
}
