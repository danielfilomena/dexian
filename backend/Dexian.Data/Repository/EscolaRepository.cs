
using Dexian.Domain.Entities;
using Dexian.Domain.Interface;

namespace Dexian.Data.Repository
{
    public class EscolaRepository : IEscola
    {

        private readonly List<Escola> _escolas = new();


        public Task<Escola> Get(int id)
        {

            try
            {

                var escola = _escolas.FirstOrDefault(x => x.iCodEscola == id);

                return Task.FromResult(escola ?? new Escola());
                                          
            }
            catch (Exception ex)
            {

                throw new Exception($@"Ocorreu o erro: " + ex.Message + "ao tentar consultar a escola!");
            }

        }

        public Task<List<Escola>> List()
        {
            try
            {

                var escolas = _escolas;

                if (escolas == null)
                {
                    throw new ArgumentNullException("Nenhuma escola encontrado!!!");
                }

                return Task.FromResult(escolas);

            }
            catch (Exception ex)
            {

                throw new Exception($@"Ocorreu o erro: " + ex.Message + "ao tentar buscar a lista de escolas!!!");

            }

        }

        public async Task<bool> Save(Escola escola)
        {

            var success = false;

            try
            {

                var colegio = await Get(escola.iCodEscola);

                if(colegio == null || colegio.iCodEscola == 0)
                {

                    escola.iCodEscola = _escolas.Count + 1;

                    _escolas.Add(escola);
                    success = true;

                }
                else
                {

                    _escolas.Remove(colegio);
                    _escolas.Add(escola);

                    success = true;

                }
                                
            }
            catch (Exception ex)
            {

                throw new Exception($@"Ocorreu o erro: " + ex.Message + "ao tentar salvar a escola!!!");
            }

            return success;

        }

        public async Task<bool> Delete(int id)
        {

            var success = false;

            try
            {

                var escola = await Get(id);

                if (escola == null || escola.iCodEscola == 0)
                {

                    throw new KeyNotFoundException($"Não foi encontrada nenhuma escola para o id: {id}");

                }

                _escolas.RemoveAll(x => x.iCodEscola == id);

                success = true;

            }
            catch (Exception ex)
            {

                throw new Exception($@"Ocorreu o erro: " + ex.Message + "ao tentar excluir uma escola!!!");
            }


            return success;

        }

    }


}
