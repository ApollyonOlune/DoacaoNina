using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DoaçãoNina.Models
{
    public class Orcamento
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Catergoria { get; set; }
        [Required]
        public string Item { get; set; }
        [Required]
        public string Valor { get; set; }
        [Required]
        public string Status { get; set; }

        public Orcamento()
        {
        }

        public Orcamento(int id, string catergoria, string item, string valor, string status)
        {
            Id = id;
            Catergoria = catergoria;
            Item = item;
            Valor = valor;
            Status = status;
        }
    }
}
