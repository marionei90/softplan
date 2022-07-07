using Microsoft.AspNetCore.Mvc;

namespace Calculate.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ShowMeTheCodeController : ControllerBase
    {
        private readonly ILogger<ShowMeTheCodeController> _logger;
        private readonly IConfigurationSection _configuration;

        public ShowMeTheCodeController(ILogger<ShowMeTheCodeController> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration.GetSection("GitHub");
        }

        /// <summary>
        /// Mostrar o endereço do Git
        /// </summary>
        /// <remarks>
        /// Exibe a URL do GitHub de onde está publicado o projeto
        /// </remarks>
        [HttpGet("showMeTheCode")]
        public async Task<IActionResult> Get()
        {
            _logger.LogInformation("Retornando a URL do Git.");

            return Ok(_configuration.GetSection("Address").Value);
        }
    }
}