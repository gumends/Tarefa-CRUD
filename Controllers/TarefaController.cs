using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Tarefa_CRUD.Models;
using UsuarioApi.Context;

namespace Tarefa_CRUD.Controllers
{
    [ApiController]
    [Route("Tarefa")]
    public class TarefaController : ControllerBase
    {

        private readonly TarefaContext _context;

        public TarefaController(TarefaContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult CriarTarefa(Tarefa tarefa)
        {

            _context.Tarefas.Add(tarefa);
            _context.SaveChanges();

            return Ok(tarefa);
        }

        [HttpGet]
        public IActionResult BuscarTodas()
        {
            var tarefa = _context.Tarefas;
            return Ok(tarefa);
        }

        [HttpGet("{id}")]
        public IActionResult BuscarPorId(int id)
        {
            var tarefa = _context.Tarefas.Find(id);

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
        public IActionResult Atualizar(Tarefa t, int id)
        {
            var tarefa = _context.Tarefas.Find(id);

            if (tarefa == null)
            {
                return NotFound();
            }

            tarefa.Titulo = t.Titulo;
            tarefa.Descricao = t.Descricao;
            tarefa.Status = t.Status;
            tarefa.Data = t.Data;

            _context.Tarefas.Update(tarefa);
            _context.SaveChanges();

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