using Dexian.Domain.Entities;

namespace Dexian.Domain.Interface
{
    public interface IAluno
    {

        Task<Aluno> Get(int id);
        Task<List<Aluno>> List();
        Task<bool> Save(Aluno aluno);
        Task<bool> Delete(int id);

    }
}
