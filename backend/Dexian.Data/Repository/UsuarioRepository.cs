using Dexian.Domain.Entities;
using Dexian.Domain.Interface;

namespace Dexian.Data.Repository
{
    public class UsuarioRepository : IUsuario
    {

        private readonly List<Usuario> _usuarios = new();

        public UsuarioRepository()
        {

            _usuarios.Add(new Usuario
            {
                
                iCodUsuario = 1,
                sNome = "TESTE",
                sSenha = "123"

            });
                
        }

        public Task<Usuario> Get(int id)
        {

            try
            {

                var usuario = _usuarios.FirstOrDefault(x => x.iCodUsuario == id);
                return Task.FromResult(usuario ?? new Usuario());

            }
            catch (Exception ex)
            {

                throw new Exception($"Ocorreu o erro: { ex.Message } ao tentar consultar o usuário!!!");

            }
           
        }

        public Task<List<Usuario>> List()
        {
            try
            {

                var usuarios = _usuarios;
                return Task.FromResult(usuarios);

            }
            catch (Exception ex)
            {

                throw new Exception($"Ocorreu o erro: { ex.Message} ao tentar listar os usuários!!!");

            }
        }

        public async Task<bool> Save(Usuario usuario)
        {

            var success = false;

            try
            {

                var user = await Get(usuario.iCodUsuario);

                if (user == null || user.iCodUsuario == 0)
                {

                    _usuarios.Add(usuario);
                    success = true;

                }
                else
                {

                    _usuarios.Remove(user);
                    _usuarios.Add(usuario);

                    success = true;

                }

            }
            catch (Exception ex)
            {

                throw new Exception($"Ocorreu o erro: { ex.Message } ao tentar salvar o usuário!!!");
            }

            return success;

        }

        public async Task<bool> Delete(int id)
        {

            var success = false;

            try
            {

                var usuario = await Get(id);

                if (usuario == null || usuario.iCodUsuario == 0)
                {

                    throw new KeyNotFoundException("Nenhum usuário encontrado!!!");

                }

                _usuarios.RemoveAll(x => x.iCodUsuario == id);
                success = true;


            }
            catch (Exception ex)
            {

                throw new Exception($"Ocorreu o erro: { ex.Message } ao tentar excluir o usuário!!!");

            }

            return success;

        }
      
        public Task<bool> ValidarUsuario(Usuario usuario)
        {

            var success = false;

            try
            {

                var user = _usuarios.FirstOrDefault(x => x.sNome?.ToLower() == usuario.sNome?.ToLower() && x.sSenha?.ToLower() == usuario.sSenha?.ToLower());

                if (user == null)
                {
                    throw new KeyNotFoundException("Usuário não cadastrado!!!");
                }

                success = true;               

            }
            catch (Exception ex)
            {

                throw new Exception($"Ocorreu o erro: { ex.Message } na validação do usuário!!!");

            }

            return Task.FromResult(success);

        }
    }
}
