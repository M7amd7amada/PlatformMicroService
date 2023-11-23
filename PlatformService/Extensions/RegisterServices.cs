using Microsoft.EntityFrameworkCore;

using PlatformService.Data;

namespace PlatformService.Extensions;

public static class RegisterServices
{
    public static void ConfigureServices(this WebApplicationBuilder builder)
    {
        var connectionString = builder.Configuration
            .GetConnectionString("SqlServerConnectionString");

        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddDbContext<AppDbContext>(options =>
            options.UseInMemoryDatabase("InMem"));
        builder.Services.AddScoped<IPlatformRepo, PlatformRepo>();
        builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
    }
}