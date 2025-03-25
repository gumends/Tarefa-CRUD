using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tarefa_CRUD.DTO
{
    public class TarefaDTO
    {
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public DateTime Data { get; set; }
    }
}