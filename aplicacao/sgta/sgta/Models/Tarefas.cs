using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace sgta.Models
{
    public class Tarefas
    {
        public int id { get; set; }

        [Required(ErrorMessage = "Informe o nome da tarefa")]
        public string nome { get; set; }

        [Required(ErrorMessage = "Informe a data de cadastro da tarefa")]
        public string dataCadastro { get; set; }

        [Required(ErrorMessage = "Informe a data limite de entrega da tarefa")]
        public string dataLimite { get; set; }
    }
}