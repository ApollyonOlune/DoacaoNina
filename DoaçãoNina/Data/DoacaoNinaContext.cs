using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using DoaçãoNina.Models;

namespace DoacaoNina.Data
{
    public class DoacaoNinaContext : DbContext
    {
        public DoacaoNinaContext (DbContextOptions<DoacaoNinaContext> options)
            : base(options)
        {
        }

        public DbSet<DoaçãoNina.Models.Feedback> Feedback { get; set; }

        public DbSet<DoaçãoNina.Models.UltDoa> UltDoa { get; set; }

        public DbSet<DoaçãoNina.Models.ConhecaANina> ConhecaANina { get; set; }

        public DbSet<DoaçãoNina.Models.Orcamento> Orcamento { get; set; }

        public DbSet<DoaçãoNina.Models.doacao> doacao { get; set; }

    }
}
