using AutoMapper;
using Dexian.Application.Dtos;
using Dexian.Application.Interfaces;
using Dexian.Domain.Entities;
using Dexian.Domain.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dexian.Application.Services
{
    public class UsuarioService : IUsuarioService
    {

        private readonly IUsuario _usuario;
        private readonly IMapper _mapper;
        private readonly ITokenService _token;

        public UsuarioService(IUsuario usuario, IMapper mapper, ITokenService token)
        {

            _usuario = usuario;
            _mapper = mapper;
            _token = token;

        }

        
        public async Task<UsuarioDto> Get(int id)
        {

            try
            {

                var usuario = await _usuario.Get(id);
                return _mapper.Map<UsuarioDto>(usuario);

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);

            }

        }

        public async Task<List<UsuarioDto>> List()
        {

            try
            {

                var usuarios = await _usuario.List();
                return _mapper.Map<List<UsuarioDto>>(usuarios);

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);

            }

        }

        public async Task<bool> Save(UsuarioDto usuario)
        {

            try
            {

                var user = _mapper.Map<Usuario>(usuario);
                var result = await _usuario.Save(user);

                return result;

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);

            }

        }

        public async Task<bool> Delete(int id)
        {

            try
            {

                var result = await _usuario.Delete(id);
                return result;

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);

            }

        }

        public async Task<string?> Login(UsuarioDto usuario)
        {
            
            try
            {

                var user = _mapper.Map<Usuario>(usuario);
                var result = await _usuario.ValidarUsuario(user);

                if (result)
                {
                    var token = await _token.GenereteToken(usuario);
                    return token;
                }
               
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);

            }

            return null;

        }
    }
}
