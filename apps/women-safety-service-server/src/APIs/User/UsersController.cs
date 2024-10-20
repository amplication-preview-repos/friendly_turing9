using Microsoft.AspNetCore.Mvc;

namespace WomenSafetyService.APIs;

[ApiController()]
public class UsersController : UsersControllerBase
{
    public UsersController(IUsersService service)
        : base(service) { }
}
