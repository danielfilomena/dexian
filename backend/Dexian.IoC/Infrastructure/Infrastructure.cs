
using Dexian.Application.Interfaces;
using Dexian.Application.Security;
using Dexian.Application.Services;
using Dexian.Data.Repository;
using Dexian.Domain.Interface;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Dexian.IoC.Infrastructure
{
    public static class Infrastructure
    {

        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {

            var key = Encoding.ASCII.GetBytes("EBA50460624FFF1AF42E842489E67873");

            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
                .AddJwtBearer(x =>
                {
                    x.RequireHttpsMetadata = false;
                    x.SaveToken = true;
                    x.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(key),
                        ValidateIssuer = false,
                        ValidateAudience = false
                    };
                });

            services.AddSingleton<IEscola, EscolaRepository>();
            services.AddSingleton<IAluno, AlunoRepository>();
            services.AddSingleton<IUsuario, UsuarioRepository>();

            services.AddSingleton<IEscolaService, EscolaService>();
            services.AddSingleton<IAlunoService, AlunoService>();
            services.AddSingleton<IUsuarioService, UsuarioService>();
            services.AddSingleton<ITokenService, TokenService>();

            return services;

        }

    }
}
