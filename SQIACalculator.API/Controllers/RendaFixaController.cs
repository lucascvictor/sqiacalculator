using Microsoft.AspNetCore.Mvc;
using SQIACalculator.Domain.DTOs;
using SQIACalculator.Domain.Interfaces;
using System.Text.Json;

namespace SQIACalculator.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RendaFixaController(IRendaFixaService service, ILogger<RendaFixaController> logger) : ControllerBase
    {
        private readonly IRendaFixaService _service = service;
        private readonly ILogger _logger = logger;

        [HttpGet("posfixado")]
        public IActionResult PosFixado([FromQuery] ConsultaPosFixadoDTO consulta)
        {
            try
            {
                _logger.LogInformation("Consulta iniciada: {consulta}", JsonSerializer.Serialize(consulta));
                return Ok(_service.CalcularIndexadorPosFixado(consulta));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao calcular aplicação do indexador para este título pós fixado");
                return StatusCode(500, "Erro interno");
            }
        }
    }
}
