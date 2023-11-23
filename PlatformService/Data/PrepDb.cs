using PlatformService.Models;

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
        if (!context.Platforms.Any())
        {
            Console.WriteLine("---> Seeding Data....");

            context.Platforms.AddRange(GenerateMockPlatforms());
            context.SaveChanges();
        }
        else
        {
            Console.WriteLine("---> We Already Have Data!!");
        }
    }

    private static IEnumerable<Platform>  GenerateMockPlatforms()
    {
            List<Platform> platforms = [];
            Random random = new();
            string[] platformNames = ["Xbox", "PlayStation", "Nintendo Switch",
                    "PC", "Mobile", "VR Headset", "Streaming Service"];
            string[] publishers = ["Microsoft", "Sony", "Nintendo",
                    "Valve", "Ubisoft", "EA", "Google"];
            for (int i = 1; i <= platformNames.Length; i++)
            {
                Platform platform = new()
                {
                    Id = i,
                    Cost = (decimal)(random.NextDouble() * 100),
                    Name = platformNames[random.Next(platformNames.Length)],
                    Publisher = publishers[random.Next(publishers.Length)]
                };
                platforms.Add(platform);
            }
            return platforms;
    }
}