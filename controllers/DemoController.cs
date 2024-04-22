using LoggingMetricsDemo.Models;
using Microsoft.AspNetCore.Mvc;

namespace LoggingMetricsDemo.controllers;

[Route("api/[controller]")]
[ApiController]
public class DemoController(ILogger<DemoController> logger) : Controller
{
    private readonly ILogger _logger = logger;
    private readonly Random _random = new();

    [HttpGet]
    [Route("CreateException")]
    public async Task<IActionResult> CreateException()
    {
        var randomNumber = _random.Next(10, 200);

        try
        {
            await Task.Delay(randomNumber);
            throw new Exception("This is a test exception");
        }
        catch (Exception e)
        {
            _logger.LogError(e, "Exception thrown");
            return StatusCode(500);
        }
    }

    [HttpGet]
    [Route("UserAction")]
    public async Task<IActionResult> CreateUser()
    {
        _logger.LogInformation("Start User creation...");

        try
        {
            var randomNumber = _random.Next(10, 300);

            await Task.Delay(randomNumber);
            var user = new User
            {
                Name = "John Doe",
                Email = "john.doe@aol.com",
                Password = "password"
            };

            _logger.LogInformation("User created: {@User}", user);
        }
        catch (Exception e)
        {
            _logger.LogError(e, "Exception thrown");
            return StatusCode(500);
        }

        _logger.LogInformation("User creation completed");

        return Ok("User created!");
    }
}