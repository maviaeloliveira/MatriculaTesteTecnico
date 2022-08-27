using Matricula.Domain.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matricula.Domain.Entities
{
    public class MatriculaAluno:Entity
    {
        public DateTime DataMatricula { get; set; }
        public int IdAluno { get; set; }
        public Aluno Aluno { get; set; }

        public MatriculaAluno(DateTime dataMatricula, int idAluno)
        {
            DataMatricula = dataMatricula;
            IdAluno = idAluno;

            Validate(this, new MatriculaAlunoValidator());
        }

        public MatriculaAluno(Aluno aluno, DateTime dataMatricula)
        {
            Aluno = aluno;
            DataMatricula = dataMatricula;            

            Validate(this, new MatriculaAlunoValidator());
        }
        public MatriculaAluno(Aluno aluno)
        {
            Aluno = aluno;
            DataMatricula = DateTime.Now;

            Validate(this, new MatriculaAlunoValidator());
        }

        //public MatriculaAluno()
        //{

        //}
    }
}
