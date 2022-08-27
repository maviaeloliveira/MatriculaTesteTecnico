using FluentValidation;
using Matricula.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matricula.Domain.Validation
{
    public class AlunoValidator : AbstractValidator<Aluno>
    {
		public AlunoValidator()
		{
			//RuleFor(a => a.Id)
			//	.NotEmpty()
			//	.WithMessage("Código Inválido");
			RuleFor(a => a.Nome)
				.NotEmpty()
				.WithMessage("O Nome é um campo obrigatório");

		}
	}
}
