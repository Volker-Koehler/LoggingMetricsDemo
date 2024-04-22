using Microsoft.AspNetCore.Mvc;

namespace LoggingMetricsDemo.controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class DemoController(ILogger<DemoController> logger) : Controller
    {
        private readonly ILogger _logger = logger;

        [HttpGet]
        [Route("CreateException")]
        public async Task<IActionResult> CreateException()
        {

            try
            {
                await Task.Delay(100);
                throw new Exception("This is a test exception");
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Exception thrown");
                return StatusCode(500);
            }

            return Ok("This will never happen!");
        }
    }
}
