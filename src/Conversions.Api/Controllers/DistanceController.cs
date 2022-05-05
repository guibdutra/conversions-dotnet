using System.Net;
using Conversions.Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Conversions.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DistanceController : ControllerBase
    {
        private readonly ILogger<DistanceController> _logger;

        public DistanceController(ILogger<DistanceController> logger)
        {
            _logger = logger;
        }

        [HttpGet("miles/{distance}")]
        [ProducesResponseType(typeof(Distance), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ErrorException), (int)HttpStatusCode.BadRequest)]
        public ActionResult<Distance> GetConversionMiles(double distance)
        {
            _logger.LogInformation(
                $"Received distance for conversion: {distance}");

            if (distance <= 0)
            {
                var errorMessage =
                    $"Invalid Distance in Miles: {distance}";
                _logger.LogError(errorMessage);
                return new BadRequestObjectResult(
                    new ErrorException()
                    {
                        Mensagem = errorMessage
                    });
            }

            var result = new Distance(distance);
            _logger.LogInformation(
                $"{result.Miles} Miles = " +
                $"{result.Km} Km");
            return result;
        }
    }
}