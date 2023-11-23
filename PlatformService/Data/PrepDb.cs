namespace PlatformService.Data;

public static class PrepDb
{
    public static void PrepPopulation(IApplicationBuilder app)
    {
        using(var serviceScope = app.ApplicationServices.CreateScope())
        {
            var context = serviceScope.ServiceProvider.GetService<AppDbContext>();

            if (context is not null)
                SeedData(context);
            else
                throw new ArgumentNullException(nameof(context));
        }
    }

    private static void SeedData(AppDbContext context)
    {

    }
}