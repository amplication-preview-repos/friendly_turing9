using WomenSafetyService.APIs;

namespace WomenSafetyService;

public static class ServiceCollectionExtensions
{
    /// <summary>
    /// Add services to the container.
    /// </summary>
    public static void RegisterServices(this IServiceCollection services)
    {
        services.AddScoped<IEmergencyContactsService, EmergencyContactsService>();
        services.AddScoped<ILocationsService, LocationsService>();
        services.AddScoped<ISafePathsService, SafePathsService>();
        services.AddScoped<IUsersService, UsersService>();
    }
}
