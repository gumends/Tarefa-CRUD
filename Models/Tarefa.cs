using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tarefa_CRUD.Models
{
    public class Tarefa
    {
        public Guid Id { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public DateTime Data { get; set; }
        public bool Status { get; set; } = true;
    }
}