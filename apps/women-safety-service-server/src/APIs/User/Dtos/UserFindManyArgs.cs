using Microsoft.AspNetCore.Mvc;
using WomenSafetyService.APIs.Common;
using WomenSafetyService.Infrastructure.Models;

namespace WomenSafetyService.APIs.Dtos;

[BindProperties(SupportsGet = true)]
public class UserFindManyArgs : FindManyInput<User, UserWhereInput> { }
