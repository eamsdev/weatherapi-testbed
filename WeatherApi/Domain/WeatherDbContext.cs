using Microsoft.EntityFrameworkCore;

namespace WeatherApi.Domain;

public class WeatherDbContext : DbContext
{    
    public WeatherDbContext(DbContextOptions options) : base(options)
    {
    }
    
    public DbSet<Weather> Weathers { get; set; }
}