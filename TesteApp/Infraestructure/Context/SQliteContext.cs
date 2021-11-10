using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using TesteApp.Infraestructure.Model;

namespace TesteApp.Infraestructure.Context
{
    public class SQliteContext : DbContext
    {
        public DbSet<Model.Produto> Produtos { get; set; }
        public DbSet<Model.ProdutoCosif> ProdutosCosif { get; set; }
        public DbSet<Model.MovimentoManual> MovimentosManuais { get; set; }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            optionsBuilder.UseSqlite("Filename=TestDatabase", options =>
            {
                options.MigrationsAssembly(Assembly.GetExecutingAssembly().FullName);
            });

            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Produto>().ToTable("Produto", "teste");
            modelBuilder.Entity<Produto>(entity =>
            {
                entity.HasKey(k => k.COD_PRODUTO);
            });
            base.OnModelCreating(modelBuilder);



            modelBuilder.Entity<ProdutoCosif>().ToTable("ProdutoCosif", "teste");
            modelBuilder.Entity<ProdutoCosif>(entity =>
            {
                entity.HasKey(k => k.COD_COSIF);
            });
            base.OnModelCreating(modelBuilder);




            modelBuilder.Entity<MovimentoManual>().ToTable("MovimentoManual", "teste");
            modelBuilder.Entity<MovimentoManual>(entity =>
            {
                entity.HasKey(k => k.ID);
            });


            base.OnModelCreating(modelBuilder);

        }

    }


}
