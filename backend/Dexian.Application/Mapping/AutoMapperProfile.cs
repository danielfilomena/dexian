
using AutoMapper;
using Dexian.Application.Dtos;
using Dexian.Domain.Entities;

namespace Dexian.Application.Mapping
{
    public class AutoMapperProfile : Profile
    {

        public AutoMapperProfile()
        {

            CreateMap<EscolaDto, Escola>().ReverseMap();
            CreateMap<AlunoDto, Aluno>().ReverseMap();
            CreateMap<UsuarioDto, Usuario>().ReverseMap();

        }

    }
}
