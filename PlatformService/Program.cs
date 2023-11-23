using PlatformService.Data;
using PlatformService.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.ConfigureServices();

var app = builder.Build();

app.UseHttpsRedirection();
app.MapControllers();

PrepDb.PrepPopulation(app);
app.Run();
