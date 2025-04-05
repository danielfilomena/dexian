using Dexian.Application.Dtos;


namespace Dexian.Application.Interfaces
{
    public interface IUsuarioService
    {
        Task<UsuarioDto> Get(int id);
        Task<List<UsuarioDto>> List();
        Task<bool> Save(UsuarioDto usuario);

        Task<string?> Login(UsuarioDto usuario);

        Task<bool> Delete(int id);

    }
}
