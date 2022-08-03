using IP.Desafio.Application.Interfaces;
using IP.Desafio.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace IP.Desafio.Infra.CrossCutting.IoC
{
    public static class BootStrapper
    {
        public static IServiceCollection AddRegisterServices(this IServiceCollection services)
        {
            services.AddScoped<IUsuarioApplication, UsuarioApplication>();
            return services;
        }
    }
}
