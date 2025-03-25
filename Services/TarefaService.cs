using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Tarefa_CRUD.Context;
using Tarefa_CRUD.DTO;
using Tarefa_CRUD.Models;

namespace Tarefa_CRUD.Services
{
    public class TarefaServices
    {
        private readonly TarefaContext _context;

        public TarefaServices(TarefaContext context)
        {
            _context = context;
        }

        public void CriarTarefa(Tarefa t)
        {
            _context.Tarefas.Add(t);
            _context.SaveChanges();
        }

        public List<Tarefa> BuscarTodas()
        {
            var tarefa = _context.Tarefas;
            return tarefa.ToList();
        }

        public Tarefa buscaPorId(Guid id)
        {
            var tarefa = _context.Tarefas.Find(id);

            return tarefa;
        }

        public Tarefa AtualizarTarefa(TarefaDTO t, Guid id)
        {
            Tarefa tarefa = _context.Tarefas.Find(id);

            tarefa.Titulo = t.Titulo;
            tarefa.Descricao = t.Descricao;
            tarefa.Data = t.Data;

            _context.Tarefas.Update(tarefa);
            _context.SaveChanges();

            return tarefa;
        }
    }
}