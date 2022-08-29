using Matricula.Application.Exceptions;
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
        public ActionResult AtualizarTempoEmSegundos(int valor)
        {
            try
            {
                 _configuracaoSistemaService.AlterarTempoDeExecucao(valor);

                return Ok(204);
            }
            catch (BusinessException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                   "Ocorreu um problema ao tratar a sua solicitação.");
            }
        }

    }
}
