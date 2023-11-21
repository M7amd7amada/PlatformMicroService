using PlatformService.Models;
using Microsoft.EntityFrameworkCore;

namespace PlatformService.Data;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<Platform> Platforms { get; set; }
}