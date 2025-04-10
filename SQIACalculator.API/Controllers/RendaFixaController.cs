using Microsoft.AspNetCore.Mvc;
using SQIACalculator.Domain.Entities;
using SQIACalculator.Domain.Interfaces;

namespace SQIACalculator.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RendaFixaController(IJurosService service) : ControllerBase
    {
        private readonly IJurosService _service = service;

        [HttpGet("posfixado")]
        public IActionResult PosFixado([FromQuery] Consulta consulta)
        {
            var resultado = _service.CalcularJurosCompostos(consulta.ValorInicial, consulta.DataInicio, consulta.DataFim);

            return Ok(resultado);
        }
    }
}
