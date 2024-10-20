using WomenSafetyService.Infrastructure;

namespace WomenSafetyService.APIs;

public class UsersService : UsersServiceBase
{
    public UsersService(WomenSafetyServiceDbContext context)
        : base(context) { }
}
