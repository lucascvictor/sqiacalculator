using Microsoft.AspNetCore.Mvc;
using SQIACalculator.Domain.DTOs;
using SQIACalculator.Domain.Interfaces;
using System.Text.Json;

namespace SQIACalculator.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RendaFixaController(IJurosService service, ILogger<RendaFixaController> logger) : ControllerBase
    {
        private readonly IJurosService _service = service;
        private readonly ILogger _logger = logger;

        [HttpGet("posfixado")]
        public IActionResult PosFixado([FromQuery] ConsultaDTO consulta)
        {
            try
            {
                _logger.LogInformation("Consulta iniciada: {consulta}", JsonSerializer.Serialize(consulta));

                var resultado = _service.CalcularJurosCompostos(consulta.ValorInicial, consulta.DataInicio, consulta.DataFim);

                return Ok(resultado);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao calcular juros para este título pós fixado");
                return StatusCode(500, "Erro interno");
            }
        }
    }
}
