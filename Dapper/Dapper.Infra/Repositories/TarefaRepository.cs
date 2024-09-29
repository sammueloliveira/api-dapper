using Dapper.Domain.Entities;
using Dapper.Domain.Interface;
using Dapper.Infra.Data;

namespace Dapper.Infra.Repositories
{
    public class TarefaRepository : ITarefa
    {
        private readonly Contexto _contexto;

        public TarefaRepository(Contexto contexto)
        {
            _contexto = contexto;
        }

        public async Task Add(Tarefa tarefa)
        {
            var sql = "INSERT INTO Tarefas (Descricao, Completa) VALUES (@Descricao, @Completa)";
            await _contexto.Connection.ExecuteAsync(sql, tarefa);
        }

        public async Task Update(Tarefa tarefa)
        {
            var sql = "UPDATE Tarefas SET Descricao = @Descricao, Completa = @Completa WHERE Id = @Id";
            await _contexto.Connection.ExecuteAsync(sql, tarefa);
        }

        public async Task Delete(Tarefa objeto)
        {
            var sql = "DELETE FROM Tarefas WHERE Id = @Id";
            await _contexto.Connection.ExecuteAsync(sql, new { Id = objeto.Id });
        }




        public async Task<Tarefa> GetEntityById(int id)
        {
            var sql = "SELECT * FROM Tarefas WHERE Id = @Id";
            return await _contexto.Connection.QuerySingleOrDefaultAsync<Tarefa>(sql, new { Id = id });
        }

        public async Task<List<Tarefa>> List()
        {
            var sql = "SELECT * FROM Tarefas";
            return (await _contexto.Connection.QueryAsync<Tarefa>(sql)).AsList();
        }

      
    }
}
