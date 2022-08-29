

using AutoMapper;
using Matricula.Application.Exceptions;
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

                      

        public async Task<IQueryable<MatriculaAluno>> GetAll()
        {
            return await _unitOfWork.matriculaAlunoRepository.Get();
        }

        public async Task<MatriculaAluno> GetById(int? id)
        {
            var matricula = await _unitOfWork.matriculaAlunoRepository.GetById(id);
            return matricula;
        }
        public async Task<List<MatriculaAluno>> GetMatriculas()
        {
            var matriculas = await _unitOfWork.matriculaAlunoRepository.GetMatriculas();

            return matriculas.ToList();
        }
        public async Task<List<MatriculaAluno>> GetMatriculaPorAluno(string nome)
        {
            var matriculas = await _unitOfWork.matriculaAlunoRepository.GetMatriculaPorAluno(nome);

            return matriculas.ToList();
        }


        

        public async Task AddMatriculaAlunoAleatorio()
        {
            var matricula = new MatriculaAluno(new Aluno(Faker.Name.FullName()));

            await this.Add(matricula);
        }

        public async Task Add(MatriculaAluno matricula)
        {
            if (matricula.Aluno.Invalid)
                throw new BusinessException("Nome do aluno obrigatório");
            else
            {
                matricula.Aluno = await _unitOfWork.alunoRepository.Add(matricula.Aluno);

                await _unitOfWork.matriculaAlunoRepository.Add(matricula);

                _unitOfWork.Commit();
            }            
        }
        public async Task Update(MatriculaAluno matriculaUpdate)
        {
            try
            {
                var matricula = await this.GetByIdComRelacionamento(matriculaUpdate.Id);

                if (matricula == null)
                    throw new NotFoundException("Matricula informada não existe");
                if (matricula.IdAluno != matriculaUpdate.Aluno.Id)
                    throw new BusinessException("Aluno informado diferente do aluno na base de dados");
                if(matriculaUpdate.Aluno.Invalid)
                    throw new BusinessException(string.Join(", ", matriculaUpdate.Aluno.ValidationResult.Errors.Select(a=> a.ErrorMessage)));
                
                matricula.Aluno = matriculaUpdate.Aluno;
                
                await _unitOfWork.alunoRepository.Update(matriculaUpdate.Aluno);
                await _unitOfWork.matriculaAlunoRepository.Update(matriculaUpdate);
                _unitOfWork.Commit();
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        
        public async Task Remove(int? id)
        {
            try
            {
                var matricula = await this.GetByIdComRelacionamento(id);

                if (matricula == null)
                    throw new NotFoundException("Matricula informada não existe");
                
                await _unitOfWork.alunoRepository.Delete(matricula.Aluno);
                await _unitOfWork.matriculaAlunoRepository.Delete(matricula);
                _unitOfWork.Commit();
            }
            catch (Exception ex)
            {
                throw;
            }

        }

        public async Task RemoveTodosRegistros()
        {
            var matriculas = await _unitOfWork.matriculaAlunoRepository.GetMatriculas();

            foreach (var item in matriculas)
            {
                await _unitOfWork.alunoRepository.Delete(item.Aluno);
                await _unitOfWork.matriculaAlunoRepository.Delete(item);
            }

            _unitOfWork.Commit();
        }

        protected async Task<MatriculaAluno> GetByIdComRelacionamento(int? id)
        {
            return await _unitOfWork.matriculaAlunoRepository.GetByIdComRelacionamento(id);
        }


    }
}
