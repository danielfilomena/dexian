using AutoMapper;
using Dexian.Application.Dtos;
using Dexian.Application.Interfaces;
using Dexian.Domain.Entities;
using Dexian.Domain.Interface;

namespace Dexian.Application.Services
{
    public class EscolaService : IEscolaService
    {

        private readonly IEscola _escola;
        private readonly IMapper _mapper;

        public EscolaService(IEscola escola, IMapper mapper)
        {

            _escola = escola;
            _mapper = mapper;

        }
        public async Task<EscolaDto> Get(int id)
        {

            try
            {

                var escola = await _escola.Get(id);
                return _mapper.Map<EscolaDto>(escola);

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);

            }

        }

        public async Task<List<EscolaDto>> List()
        {

            try
            {

                var escolas = await _escola.List();
                return _mapper.Map<List<EscolaDto>>(escolas);

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);

            }

        }

        public async Task<bool> Save(EscolaDto escola)
        {

            try
            {

                var colegio = _mapper.Map<Escola>(escola);
                var result = await _escola.Save(colegio);

                return result;

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);

            }

        }

        public async Task<bool> Delete(int id)
        {

            try
            {

                var result = await _escola.Delete(id);
                return result;

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);

            }

        }

    }
}
