
using Dexian.Application.Dtos;

namespace Dexian.Application.Interfaces
{
    public interface IAlunoService
    {

        Task<AlunoDto> Get(int id);
        Task<List<AlunoDto>> List();
        Task<bool> Save(AlunoDto aluno);
        Task<bool> Delete(int id);

    }
}
