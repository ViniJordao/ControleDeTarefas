using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace ControleDeTarefas
{
    public class Tarefas
    {
        public  int Id { get; set; }
        public string Titulo { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime DataFinalizacao { get; set; }
        public string Prioridade { get; set; }
        public string Percentual { get; set; }

        public Tarefas(int id, string titulo, DateTime dataCriacao, DateTime dataFinalizacao, string prioridade, string percentual)
        {
            Id = id;
            Titulo = titulo;
            DataCriacao = dataCriacao;
            DataFinalizacao = dataFinalizacao;
            Prioridade = prioridade;
            Percentual = percentual;
        }

      


    }
}