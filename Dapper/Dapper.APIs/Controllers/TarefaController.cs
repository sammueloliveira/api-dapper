using Dapper.Domain.Entities;
using Dapper.Domain.Interface;
using Dapper.Domain.InterfaceServices;
using Microsoft.AspNetCore.Mvc;

namespace Dapper.APIs.Controllers
{
    [Route("api/tarefa")]
    [ApiController]
    public class TarefaController : ControllerBase
    {
        private readonly ITarefa _tarefa;
        private readonly ITarefaServices _tarefaService;

        public TarefaController(ITarefa tarefa, ITarefaServices tarefaService)
        {
            _tarefa = tarefa;
            _tarefaService = tarefaService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Tarefa>>> GetAll()
        {
            var tarefas = await _tarefa.List();
            return Ok(tarefas);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Tarefa>> GetById(int id)
        {
            var tarefa = await _tarefa.GetEntityById(id);
            if (tarefa == null)
            {
                return NotFound();
            }
            return Ok(tarefa);
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] Tarefa tarefa)
        {
            await _tarefaService.AddTarefa(tarefa);
            return CreatedAtAction(nameof(GetById), new { id = tarefa.Id }, tarefa);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, [FromBody] Tarefa tarefa)
        {
            if (id != tarefa.Id)
            {
                return BadRequest();
            }

            await _tarefaService.UpdateTarefa(tarefa);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {

            var tarefaExistente = await _tarefa.GetEntityById(id);
            if (tarefaExistente == null)
            {
                return NotFound();
            }

            await _tarefa.Delete(tarefaExistente);
            return NoContent();
        }
    }
}

