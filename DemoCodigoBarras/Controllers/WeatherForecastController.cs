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

        [HttpPost]
        public async Task<ActionResult> Get([FromBody] Base97TelecommBanco base97)
        {
            Base97TelecommBanco b97 = new Base97TelecommBanco();
            
            b97.Convenio = base97.Convenio;
            b97.Referencia = base97.Referencia;           
            b97.Fecha = base97.Fecha;
            b97.Importe = base97.Importe;
            
            Util.CalcularBase97TelecommBanco(b97);
            return Ok( new { 
                cadena= b97.CadenaFinal 
            });
            //return "Saludos desde el API...";
        }
    }
}
