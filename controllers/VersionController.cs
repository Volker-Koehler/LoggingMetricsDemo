using Microsoft.AspNetCore.Mvc;

namespace LoggingMetricsDemo.controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class VersionController(ILogger<VersionController> logger) : Controller
    {
        private readonly ILogger _logger = logger;
        private readonly Random _random = new();

        [HttpGet]
        [Route("GetVersion")]
        public async Task<IResult> GetVersion()
        {
            _logger.LogInformation("Version requested");
            await Task.Delay(_random.Next(10,200));
            return Results.Ok("Version 1.0");
        }
    }
}
