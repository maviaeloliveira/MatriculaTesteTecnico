using AutoMapper;
using Matricula.Application.DTOs.Aluno;
using Matricula.Application.DTOs.MatriculaAluno;
using Matricula.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matricula.Application.Mappings
{
    public class DomainToDTOMappingProfile : Profile
    {
        public DomainToDTOMappingProfile()
        {
            CreateMap<Aluno, AlunoDTO>().ReverseMap();
            CreateMap<Aluno, AlunoInsertDTO>().ReverseMap();

            CreateMap<MatriculaAluno, MatriculaAlunoDTO>().ReverseMap();
            CreateMap<MatriculaAluno, MatriculaAlunoInsertDTO>().ReverseMap();
            CreateMap<MatriculaAluno, MatriculaAlunoUpdateDTO>().ReverseMap();

            
        }
    }
}
