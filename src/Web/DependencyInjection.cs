using Web.Services.Implementations;
using Web.Services.Interfaces;

namespace Web;

public static class DependencyInjection
{
    public static void AddServices(this IServiceCollection services)
    {
        services.AddScoped<IBillOcrService, BillOcrService>();
    }
}