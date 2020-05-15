using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace TF_PSA.PL
{
    public class LeilaoContext : DbContext
    {
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Item> Itens { get; set; }
        public DbSet<Lance> Lances { get; set; }
        public DbSet<Leilao> Leiloes { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
           .UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=DBMovieCF;Trusted_Connection=True;");
        }
    }
}
