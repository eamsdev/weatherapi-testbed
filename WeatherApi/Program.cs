using Microsoft.EntityFrameworkCore;
using WeatherApi.Domain;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Configuration.AddEnvironmentVariables();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<WeatherDbContext>(options =>
{
    var connectionString = builder.Configuration.GetConnectionString("dbConnectionString");
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

using var scope = app.Services.CreateScope();
var context = scope.ServiceProvider.GetRequiredService<WeatherDbContext>();
await context.Database.MigrateAsync();
if (!await context.Weathers.AnyAsync())
{
    await context.Weathers.AddRangeAsync(new List<Weather>
    {
        new() { Temperature = 25, Location = "Melbourne" },
        new() { Temperature = 35, Location = "Bangkok" },
        new() { Temperature = 12, Location = "Paris" },
    });

    await context.SaveChangesAsync();
}

await app.RunAsync();