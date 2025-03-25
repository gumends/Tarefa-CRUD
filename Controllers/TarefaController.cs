using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Tarefa_CRUD.Models;
using Tarefa_CRUD.Context;
using Tarefa_CRUD.Services;
using Tarefa_CRUD.DTO;

namespace Tarefa_CRUD.Controllers
{
    [ApiController]
    [Route("Tarefa")]
    public class TarefaController : ControllerBase
    {

        private readonly TarefaContext _context;
        private readonly TarefaServices _tarefaServices;

        public TarefaController(TarefaContext context, TarefaServices tarefaServices)
        {
            _context = context;
            _tarefaServices = tarefaServices;
        }

        [HttpPost]
        public IActionResult CriarTarefa(TarefaDTO tarefaDTO)
        {
            Tarefa tarefa = new Tarefa();

            tarefa.Titulo = tarefaDTO.Titulo;
            tarefa.Descricao = tarefaDTO.Descricao;
            tarefa.Data = tarefaDTO.Data;

            _tarefaServices.CriarTarefa(tarefa);
            return Ok(tarefa);
        }

        [HttpGet]
        public IActionResult BuscarTodas()
        {
            var tarefa = _tarefaServices.BuscarTodas();
            return Ok(tarefa);
        }

        [HttpGet("{id}")]
        public IActionResult BuscarPorId(Guid id)
        {
            var tarefa = _tarefaServices.buscaPorId(id);
            if (tarefa == null)
            {
                return NotFound();
            }
            return Ok(tarefa);
        }

        [HttpGet("titulo/{titulo}")]
        public IActionResult BuscaPorTitulo(string titulo)
        {
            var tarefa = _context.Tarefas.Where(t => t.Titulo.Contains(titulo));
            return Ok(tarefa);
        }

        [HttpPut("{id}")]
        public IActionResult Atualizar(TarefaDTO t, Guid id)
        {
            var tarefa = _tarefaServices.AtualizarTarefa(t, id);

            if (tarefa == null)
            {
                return NotFound();
            }

            return Ok(tarefa);
        }

        [HttpDelete("{id}")]
        public IActionResult DeletarTarefa(int id)
        {
            var tarefa = _context.Tarefas.Find(id);

            _context.Tarefas.Remove(tarefa);
            _context.SaveChanges();
            return Ok(tarefa);
        }
    }
}