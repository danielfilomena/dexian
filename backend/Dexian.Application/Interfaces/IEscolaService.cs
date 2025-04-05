
using Dexian.Application.Dtos;

namespace Dexian.Application.Interfaces
{
    public interface IEscolaService
    {
        Task<EscolaDto> Get(int id);
        Task<List<EscolaDto>> List();
        Task<bool> Save(EscolaDto escola);
        Task<bool> Delete(int id);

    }
}
