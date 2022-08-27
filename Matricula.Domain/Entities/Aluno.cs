using Matricula.Domain.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matricula.Domain.Entities
{
    public class Aluno: Entity
    {
        public string Nome { get; set; }

        public ICollection<MatriculaAluno>? Matriculas { get; set; }

        public Aluno(string nome)
        {
            Nome = nome;
            Validate(this, new AlunoValidator());
        }
        public Aluno()
        {

        }
    }
}
