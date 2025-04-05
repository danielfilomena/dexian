using AutoMapper;
using Dexian.Application.Dtos;
using Dexian.Application.Interfaces;
using Dexian.Domain.Entities;
using Dexian.Domain.Interface;

namespace Dexian.Application.Services
{
    public class AlunoService : IAlunoService
    {

        private readonly IAluno _aluno;
        private readonly IMapper _mapper;

        public AlunoService(IAluno aluno, IMapper mapper)
        {

            _aluno = aluno;
            _mapper = mapper;

        }

        public async Task<AlunoDto> Get(int id)
        {

            try
            {

                var aluno = await _aluno.Get(id);
                return _mapper.Map<AlunoDto>(aluno);

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);

            }

        }

        public async Task<List<AlunoDto>> List()
        {

            try
            {

                var alunos = await _aluno.List();
                return _mapper.Map<List<AlunoDto>>(alunos);

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);

            }

        }

        public async Task<bool> Save(AlunoDto aluno)
        {

            try
            {

                var estudande = _mapper.Map<Aluno>(aluno);
                var result = await _aluno.Save(estudande);

                return result;

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);

            }

        }

        public Task<bool> Delete(int id)
        {

            try
            {

                var result = _aluno.Delete(id);
                return result;

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);

            }

        }

    }
}
