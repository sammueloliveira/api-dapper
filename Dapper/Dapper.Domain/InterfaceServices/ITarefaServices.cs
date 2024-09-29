using Dapper.Domain.Entities;

namespace Dapper.Domain.InterfaceServices
{
     public interface ITarefaServices
     {
        Task AddTarefa(Tarefa tarefa);
        Task UpdateTarefa(Tarefa tarefa);
     }
}
