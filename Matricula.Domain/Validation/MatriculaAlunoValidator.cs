using FluentValidation;
using Matricula.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matricula.Domain.Validation
{
    public class MatriculaAlunoValidator : AbstractValidator<MatriculaAluno>
	{
		public MatriculaAlunoValidator()
		{
			//RuleFor(a => a.Id)
			//	.NotEmpty()
			//	.WithMessage("Código Inválido");
			//RuleFor(a => a.IdAluno)
			//	.NotEmpty()
			//	.WithMessage("Código do Aluno Inválido");
			//RuleFor(a => a.DataMatricula)
			//	.NotEmpty()
			//	.WithMessage("Data da matrícula é um campo obrigatório");

		}

	}
}
