using AutoMapper;
using Matricula.Application.DTOs;
using Matricula.Application.DTOs.Aluno;
using Matricula.Application.DTOs.MatriculaAluno;
using Matricula.Domain.Entities;
using Matricula.Domain.Interfaces.Service;
using Microsoft.AspNetCore.Mvc;

namespace Matricula.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MatriculaAlunoController : ControllerBase
    {
        private readonly IMatriculaAlunoService _matriculaAlunoService;
        private readonly IMapper _mapper;

        public MatriculaAlunoController(IMatriculaAlunoService matriculaAlunoService, IMapper mapper)
        {
            _matriculaAlunoService = matriculaAlunoService;
            _mapper = mapper;
        }

        /// <summary>
        /// Rota responsável por criar um banco novo no sistema
        /// </summary>
        /// <param name="AlunoInsertDTO"></param>
        /// <response code="200">o aluno foi criado com sucesso</response>
        /// <response code="400">Ocorreu algum erro ao criar o aluno</response>
        /// <returns></returns>
        [HttpPost("PostMatricula")]
        public async Task<IActionResult> MatriculaAluno([FromBody] AlunoInsertDTO alunoInsertDTO)
        {
            var alunoInsert = _mapper.Map<Aluno>(alunoInsertDTO);

            var matriculaInsert = new MatriculaAluno(alunoInsert);
            await _matriculaAlunoService.Add(matriculaInsert);

            return Ok(200);
        }

        /// <summary>
        /// Atualiza os dados da matricula.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="matriculaAlunoUpdateDTO"></param>
        /// <returns></returns>
        [HttpPut("{id:int}")]
        public async Task<ActionResult> AtualizarMatricula(int id, MatriculaAlunoUpdateDTO matriculaAlunoUpdateDTO)
        {
            if (id != matriculaAlunoUpdateDTO.Id)
                return BadRequest("Informe o Id da matricula");

            var matriculaUpdate = _mapper.Map<MatriculaAluno>(matriculaAlunoUpdateDTO);

            await _matriculaAlunoService.Update(matriculaUpdate);

            return Ok(200);
        }

        /// <summary>
        /// Retorna todas as matriculas
        /// </summary>
        /// <returns></returns>
        [HttpGet("todas-matriculas")]
        public async Task<ActionResult<IEnumerable<MatriculaAlunoDTO>>> GetMatriculas()
        {
            try
            {
                var matriculas = await _matriculaAlunoService.GetMatriculas();
                return _mapper.Map<IEnumerable<MatriculaAlunoDTO>>(matriculas).ToList();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Ocorreu um problema ao tratar a sua solicitação.");
            }
        }

        /// <summary>
        /// Rota responsável por excluir a matricula
        /// </summary>
        /// <param name="id">identificador da matricula</param>
        /// <returns></returns>
        [HttpDelete("{id:int}")]
        public async Task<ActionResult<MatriculaAlunoDTO>> Delete(int id)
        {
            var matricula = await _matriculaAlunoService.GetById(id);
            if (matricula == null)
                return NotFound("Matricula não encontrada");

            await _matriculaAlunoService.Remove(id);
            return Ok(200);
        }

        /// <summary>
        /// Rota que retorna as matrículas pelo nome do aluno
        /// </summary>
        /// <param name="descricao"></param>
        /// <returns></returns>
        [HttpGet("matricula-por-descricao")]
        public async Task<ActionResult<IEnumerable<MatriculaAlunoDTO>>> GetMatriculaPorAluno([FromQuery] string? descricao)
        {
            try
            {
                if (string.IsNullOrEmpty(descricao))
                    return BadRequest("Informe ao menos 1 caracter para a pesquisa");

                var matriculas = await _matriculaAlunoService.GetMatriculaPorAluno(descricao);
                return _mapper.Map<IEnumerable<MatriculaAlunoDTO>>(matriculas).ToList();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Ocorreu um problema ao tratar a sua solicitação.");
            }
        }

        /// <summary>
        /// Criado essa rota para ofertar a possibilidade de limpar todos os registros da base de dados.
        /// </summary>
        /// <returns></returns>
        [HttpDelete()]
        public async Task<ActionResult<MatriculaAlunoDTO>> DeletaTodosOsRegistros()
        {
            await _matriculaAlunoService.RemoveTodosRegistros();

            return Ok(200);
        }


    }
}
