using Microsoft.AspNetCore.Mvc;

namespace WeatherApi.Controllers;

[ApiController]
[Route("[controller]")]
public class HealthController : ControllerBase
{
    private readonly ILogger<HealthController> _logger;

    public HealthController(ILogger<HealthController> logger)
    {
        _logger = logger;
    }

    [HttpGet]
    public ActionResult Get()
    {
        _logger.LogInformation("Received health check, responding OK");
        return new OkResult();
    }
}