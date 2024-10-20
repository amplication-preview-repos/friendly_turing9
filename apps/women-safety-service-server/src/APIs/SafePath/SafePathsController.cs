using Microsoft.AspNetCore.Mvc;

namespace WomenSafetyService.APIs;

[ApiController()]
public class SafePathsController : SafePathsControllerBase
{
    public SafePathsController(ISafePathsService service)
        : base(service) { }
}
