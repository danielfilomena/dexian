using Dexian.Domain.Entities;
using Dexian.Domain.Interface;

namespace Dexian.Data.Repository
{
    public class AlunoRepository : IAluno
    {

        private readonly List<Aluno> _alunos = new();

        public Task<Aluno> Get(int id)
        {

            try
            {

                var aluno = _alunos.FirstOrDefault(x => x.iCodAluno == id);
                return Task.FromResult(aluno ?? new Aluno());

            }
            catch (Exception ex)
            {

                throw new Exception($"Ocorreu o erro: { ex.Message } ao tentar consultar o aluno!!!");

            }

        }

        public Task<List<Aluno>> List()
        {

            try
            {

                var alunos = _alunos;

                if (alunos == null)
                {

                    throw new ArgumentNullException("Nenhum aluno encontrado!!");

                }

                return Task.FromResult(alunos);

            }
            catch (Exception ex)
            {

                throw new Exception($"Ocorreu o erro: { ex.Message } ao tentar buscar a lista de alunos!!!");
            }
        }

        public async Task<bool> Save(Aluno aluno)
        {

            var success = false;

            try
            {

                var estudande = await Get(aluno.iCodAluno);

                if (estudande == null || estudande.iCodAluno == 0)
                {

                    aluno.iCodAluno = _alunos.Count + 1;

                    _alunos.Add(aluno);
                    success = true;

                }
                else
                {

                    _alunos.Remove(estudande);
                    _alunos.Add(aluno);
                    success = true;

                }


            }
            catch (Exception ex)
            {

                throw new Exception($"Ocorreu o erro: { ex.Message } ao salvar o aluno!!!");

            }

            return success;

        }

        public async Task<bool> Delete(int id)
        {

            var success = false;

            try
            {

                var aluno = await Get(id);

                if (aluno == null || aluno.iCodAluno == 0)
                {

                    throw new KeyNotFoundException("Nenhum aluno encontrado!!!");

                }

                _alunos.RemoveAll(x => x.iCodAluno == id);

                success = true;
                               
            }
            catch (Exception ex)
            {

                throw new Exception($"Ocorreu o erro? { ex.Message } ao tentar excluir um aluno!!!");
            }

            return success;

        }
    }
}
