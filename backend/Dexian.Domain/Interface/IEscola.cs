
using Dexian.Domain.Entities;

namespace Dexian.Domain.Interface
{
    public interface IEscola
    {
        Task<Escola> Get(int id);
        Task<List<Escola>> List();
        Task<bool> Save(Escola escola);
        Task<bool> Delete(int id);

    }
}
