using WomenSafetyService.Infrastructure;

namespace WomenSafetyService.APIs;

public class EmergencyContactsService : EmergencyContactsServiceBase
{
    public EmergencyContactsService(WomenSafetyServiceDbContext context)
        : base(context) { }
}
