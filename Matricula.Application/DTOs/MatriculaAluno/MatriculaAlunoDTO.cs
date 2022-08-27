using Matricula.Application.DTOs.Aluno;

namespace Matricula.Application.DTOs.MatriculaAluno
{
    public class MatriculaAlunoDTO
    {
        public int Id { get; set; }
        public DateTime DataMatricula { get; set; }
        public int IdAluno { get; set; }
        public AlunoDTO Aluno { get; set; }
    }
}
