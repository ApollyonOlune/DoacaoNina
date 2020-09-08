using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DoaçãoNina.Models
{
    public class UltDoa
    {
        public int ID { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime Data { get; set; }
        public string Nome { get; set; }
        public string Valor { get; set; }

        public UltDoa()
        {
        }

        public UltDoa(int iD, DateTime data, string nome, string valor)
        {
            ID = iD;
            Data = data;
            Nome = nome;
            Valor = valor;
        }
    }
}
