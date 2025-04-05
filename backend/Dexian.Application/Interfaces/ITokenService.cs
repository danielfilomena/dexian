using Dexian.Application.Dtos;

namespace Dexian.Application.Interfaces
{
    public interface ITokenService
    {

        Task<string> GenereteToken(UsuarioDto usuario);

    }
}
