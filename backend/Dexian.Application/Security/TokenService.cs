using Dexian.Application.Dtos;
using Dexian.Application.Interfaces;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Dexian.Application.Security
{
    public class TokenService : ITokenService
    {

        public Task<string> GenereteToken(UsuarioDto usuario)
        {

			try
			{

				var tokenHandler = new JwtSecurityTokenHandler();
				var key = Encoding.ASCII.GetBytes("EBA50460624FFF1AF42E842489E67873");
				var tokenDescriptor = new SecurityTokenDescriptor
				{
					Subject = new ClaimsIdentity(new[]
					{
						new Claim(ClaimTypes.Name, usuario.sNome ?? string.Empty)
					}),
					Expires = DateTime.UtcNow.AddHours(2),
					SigningCredentials = new SigningCredentials(
						new SymmetricSecurityKey(key),
						SecurityAlgorithms.HmacSha256Signature
					)
				};

				var token = tokenHandler.CreateToken(tokenDescriptor);
				return Task.FromResult(tokenHandler.WriteToken(token));

			}
			catch (Exception ex)
			{

				throw new Exception($"Ocorreu o erro: {ex.Message} ao tentar gerar o token!!!");

			}

        }

    }
}
