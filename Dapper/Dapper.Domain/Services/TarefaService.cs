using Dapper.Domain.Entities;
using Dapper.Domain.Interface;
using Dapper.Domain.InterfaceServices;

namespace Dapper.Domain.Services
{
    public class TarefaService : ITarefaServices
     {
        private readonly ITarefa _tarefa;

        public TarefaService(ITarefa tarefa)
        {
            _tarefa = tarefa;
        }

        public async Task AddTarefa(Tarefa tarefa)
        {
            await _tarefa.Add(tarefa);
        }

        public async Task UpdateTarefa(Tarefa tarefa)
        {
            var existe = await _tarefa.GetEntityById(tarefa.Id);

            if(existe != null)
            {
                existe.Descricao = tarefa.Descricao;
                existe.Completa = tarefa.Completa;

                await _tarefa.Update(existe);
            }
        }
    }
}
