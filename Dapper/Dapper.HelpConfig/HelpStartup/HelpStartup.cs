using Dapper.Domain.Interface;
using Dapper.Domain.InterfaceServices;
using Dapper.Domain.Services;
using Dapper.Infra.Data;
using Dapper.Infra.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Dapper.HelpConfig.HelpStartup
{
    public static class HelpStartup
    {
        public static void ConfigureScoped(IServiceCollection services)
        {
            

            services.AddScoped<Contexto>();
            services.AddScoped<ITarefa, TarefaRepository>();
            services.AddScoped<ITarefaServices, TarefaService>();
            
        }
    }
}
