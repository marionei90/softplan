using Calculate.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace Calculate.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CalculateController : ControllerBase
    {
        private readonly ILogger<CalculateController> _logger;
        private readonly IConfigurationSection _configuration;

        public CalculateController(ILogger<CalculateController> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration.GetSection("ReturnFeesAPI");
        }

        /// <summary>
        /// Calcular juros
        /// </summary>
        /// <remarks>
        /// Endpoint que retorna o resultado do calculo dos juros compostos.
        /// </remarks>
        /// <param name="parameters">Valor inicial e quantidade de meses para o cálculo.</param>
        [HttpGet("calculaJuros")]
        public async Task<IActionResult> Get([FromQuery] Parameters parameters)
        {
            _logger.LogInformation($"Parametros recebidos - Valor: {parameters.ValorInicial} | Meses: {parameters.Meses}");

            _logger.LogInformation("Obtendo a taxa de juros da outra API");

            using var client = new HttpClient();
            client.BaseAddress = new Uri(_configuration.GetSection("Address").Value);

            try
            {
                var response = client.GetAsync(_configuration.GetSection("Endpoint").Value);

                if (response.Result.IsSuccessStatusCode)
                {
                    var fee = await response.Result.Content.ReadAsStringAsync();

                    _logger.LogInformation($"Taxa obtida: {fee}. Calculando o resultado.");

                    var result = new Domain.Calculate(
                        fee,
                        parameters.Meses,
                        parameters.ValorInicial
                    );

                    _logger.LogInformation($"Retornando resultado obtido: {result}");

                    return Ok(result.Result);
                }
                else
                {
                    _logger.LogError($"Erro ao obter taxa: {response.Result.StatusCode}");

                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Erro ao calcular o valor final: {ex.Message}");

                return BadRequest();
            }
        }
    }
}