using Matricula.Application.DTOs.Aluno;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matricula.Application.DTOs.MatriculaAluno
{
    public class MatriculaAlunoUpdateDTO
    {
        public int Id { get; set; }
        public AlunoDTO Aluno { get; set; }
        public DateTime DataMatricula { get; set; }

    }
}
