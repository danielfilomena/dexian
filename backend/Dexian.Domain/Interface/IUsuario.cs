
using Dexian.Domain.Entities;

namespace Dexian.Domain.Interface
{
    public interface IUsuario
    {

        Task<Usuario> Get(int id);
        Task<List<Usuario>> List();
        Task<bool> Save(Usuario usuario);
        Task<bool> ValidarUsuario(Usuario usuario);
        Task<bool> Delete(int id);

    }

}
