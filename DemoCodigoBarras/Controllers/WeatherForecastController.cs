using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using Telecomm.Helper;
using Telecomm.Model;

namespace DemoCodigoBarras.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            Base97TelecommBanco b97 = new Base97TelecommBanco();
            b97.Convenio = "C0001";
            b97.Referencia = "SL202186756521PSWS";
            b97.Fecha = "10/08/2021";
            b97.Importe = "420.00";
            Util.CalcularBase97TelecommBanco(b97);
            return Ok( new { 
                cadena= b97.CadenaFinal 
            });
            //return "Saludos desde el API...";
        }
    }
}
