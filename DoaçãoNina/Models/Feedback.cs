using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DoaçãoNina.Models
{
    public class Feedback
    {
        public int ID { get; set; }
        public string Nome { get; set; }
        [Display(Name = "E-Mail")]
        public string Email { get; set; }
        public string Telefone { get; set; }
        [Required(ErrorMessage = "É nescessário que {0} esteja preenchido.")]
        public string Mensagem { get; set; }

        public Feedback()
        {
        }

        public Feedback(int iD, string nome, string email, string telefone, string mensagem)
        {
            ID = iD;
            Nome = nome;
            Email = email;
            Telefone = telefone;
            Mensagem = mensagem;
        }
    }
}
