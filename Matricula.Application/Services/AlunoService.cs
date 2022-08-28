using AutoMapper;
using Matricula.Domain.Entities;
using Matricula.Domain.Interfaces;
using Matricula.Domain.Interfaces.Service;
using Matricula.Domain.Validation;


namespace Matricula.Application.Services
{
    public class AlunoService : IAlunoService
    {
        private readonly IMapper _mapper;
        private readonly NotificationContext _notificationContext;
        private readonly IUnitOfWork _unitOfWork;

        public AlunoService(
            IMapper mapper,
            NotificationContext notificationContext,
            IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _notificationContext = notificationContext;
            _unitOfWork = unitOfWork;
        }

        public async Task Add(Aluno aluno)
        {
            if (aluno.Invalid)
                _notificationContext.AddNotifications(aluno.ValidationResult);

            await _unitOfWork.alunoRepository.Add(aluno);

            _unitOfWork.Commit();
        }

        public async Task Remove(int? id)
        {
            var aluno = await _unitOfWork.alunoRepository.GetById(id);
            await _unitOfWork.alunoRepository.Delete(aluno);
            _unitOfWork.Commit();
        }

        public async Task<IQueryable<Aluno>> GetAll()
        {
            var alunos = await _unitOfWork.alunoRepository.Get();

            return alunos;
        }

        public async Task<Aluno> GetById(int? id)
        {
            var aluno = await _unitOfWork.alunoRepository.GetById(id);

            return aluno;
        }

        public async Task Update(Aluno aluno)
        {
            await _unitOfWork.alunoRepository.Update(aluno);
            _unitOfWork.Commit();
        }

        
    }
}
