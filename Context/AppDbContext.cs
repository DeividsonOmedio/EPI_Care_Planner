using Epi_Care_Planner.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epi_Care_Planner.Context
{
    public class AppDbContext : DbContext
    {
        public DbSet<Usuario> users { get; set; }
        public DbSet<Epi> epis { get; set; }
        public DbSet<Funcionario> funcionarios { get; set; }
        public DbSet<Emprestimo> emprestimos { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string conexioDb = $"Filename={ConectionDb.DevolverRota("epi5.db3")}";
            optionsBuilder.UseSqlite(conexioDb);
        }


    }
}
