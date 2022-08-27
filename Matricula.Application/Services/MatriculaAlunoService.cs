﻿

using AutoMapper;
using Matricula.Domain.Entities;
using Matricula.Domain.Interfaces;
using Matricula.Domain.Interfaces.Service;
using Matricula.Domain.Validation;

namespace Matricula.Application.Services
{
    public class MatriculaAlunoService : IMatriculaAlunoService
    {
        private readonly IMapper _mapper;
        private readonly NotificationContext _notificationContext;
        private readonly IUnitOfWork _unitOfWork;

        public MatriculaAlunoService(
            IMapper mapper,
            NotificationContext notificationContext,
            IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _notificationContext = notificationContext;
            _unitOfWork = unitOfWork;
        }

        public async Task Add(MatriculaAluno matricula)
        {
            if (matricula.Aluno.Invalid)
                 _notificationContext.AddNotifications(matricula.ValidationResult);

            matricula.Aluno = await _unitOfWork.alunoRepository.Add(matricula.Aluno);

            await _unitOfWork.matriculaAlunoRepository.Add(matricula);

            _unitOfWork.Commit();
        }
        public async Task Update(MatriculaAluno matriculaUpdate)
        {            
            await _unitOfWork.matriculaAlunoRepository.Update(matriculaUpdate);
            _unitOfWork.Commit();
        }
        

        public async Task<MatriculaAluno> GetById(int? id)
        {
            var matricula = await _unitOfWork.matriculaAlunoRepository.GetById(id);

            return matricula;
        }

        public async Task Remove(int? id)
        {
            var matricula = await _unitOfWork.matriculaAlunoRepository.GetById(id);
            await _unitOfWork.matriculaAlunoRepository.Delete(matricula);
            _unitOfWork.Commit();
        }

        public async Task<List<MatriculaAluno>> GetMatriculaPorAluno(string nome)
        {
            var matriculas = await _unitOfWork.matriculaAlunoRepository.GetMatriculaPorAluno(nome);

            return matriculas.ToList();
        }

        public async Task<List<MatriculaAluno>> GetMatriculas()
        {
            var matriculas = await _unitOfWork.matriculaAlunoRepository.GetMatriculas();

            return matriculas.ToList();
        }

        public Task<IQueryable<MatriculaAluno>> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
