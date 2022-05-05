using System.Net;
using Conversions.Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Conversions.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class TemperatureController : ControllerBase
{
    private readonly ILogger<TemperatureController> _logger;

    public TemperatureController(ILogger<TemperatureController> logger)
    {
        _logger = logger;
    }

    [HttpGet("fahrenheit/{temperature}")]
    [ProducesResponseType(typeof(Temperature), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(ErrorException), (int)HttpStatusCode.BadRequest)]
    public ActionResult<Temperature> GetConversionFahrenheit(double temperature)
    {
        _logger.LogInformation(
            $"Received temperature for conversion: {temperature}");

        if (temperature < -459.67)
        {
            var mensagemErro =
                $"Invalid Fahrenheit temperature value: {temperature}";
            _logger.LogError(mensagemErro);
            return new BadRequestObjectResult(
                new ErrorException()
                {
                    Mensagem = mensagemErro
                });
        }

        var result = new Temperature(temperature);
        _logger.LogInformation(
            $"{result.Fahrenheit} degrees Fahrenheit = " +
            $"{result.Celsius} degrees Celsius = " +
            $"{result.Kelvin} degrees Kelvin");
        return result;
    }
}