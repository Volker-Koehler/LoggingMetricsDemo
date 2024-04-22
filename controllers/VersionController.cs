using Microsoft.AspNetCore.Mvc;

namespace LoggingMetricsDemo.controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class VersionController(ILogger<VersionController> logger) : Controller
    {
        private readonly ILogger _logger = logger;

        [HttpGet]
        [Route("GetVersion")]
        public async Task<IResult> GetVersion()
        {
            _logger.LogInformation("Version requested");
            await Task.Delay(10);
            return Results.Ok("Version 1.0");
        }
    }
}
