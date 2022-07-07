using Microsoft.AspNetCore.Mvc;
using ReturnFees.Domain;

namespace Desafio.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ReturnFeesController : ControllerBase
    {
        private readonly ILogger<ReturnFeesController> _logger;

        public ReturnFeesController(ILogger<ReturnFeesController> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// Retornar taxa
        /// </summary>
        /// <remarks>
        /// Endpoint que retorna a taxa atual de juros para o cálculo final.
        /// </remarks>
        [HttpGet("taxaJuros")]
        public async Task<IActionResult> Get()
        {
            _logger.LogInformation("Retornando resultado fixo.");

            return Ok(new ReturnFee().Fee);
        }
    }
}