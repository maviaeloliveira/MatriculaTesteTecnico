using Matricula.Domain.Interfaces.Service;
using Microsoft.AspNetCore.Mvc;

namespace Matricula.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConfiguracaoSistemaController : ControllerBase
    {
        private readonly IConfiguracaoSistemaService _configuracaoSistemaService;
        

        public ConfiguracaoSistemaController(IConfiguracaoSistemaService configuracaoSistemaService)
        {
            _configuracaoSistemaService = configuracaoSistemaService;
        }

        [HttpPut("{valor:int}")]
        public async Task<ActionResult> AtualizarTempoEmSegundos(int valor)
        {
            if (valor == 0)
                return BadRequest("Informe um valor válido");

             _configuracaoSistemaService.AlterarTempoDeExecucao(valor);

            return Ok(200);
        }

    }
}
