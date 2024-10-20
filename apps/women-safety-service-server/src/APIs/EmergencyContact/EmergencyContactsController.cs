using Microsoft.AspNetCore.Mvc;

namespace WomenSafetyService.APIs;

[ApiController()]
public class EmergencyContactsController : EmergencyContactsControllerBase
{
    public EmergencyContactsController(IEmergencyContactsService service)
        : base(service) { }
}
