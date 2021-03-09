using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using TriaCSharp.Models;

namespace triaCSharp.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base (options) { }        
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Cliente> Clientes { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {

            builder.Entity<Produto>()
                .HasData(new List<Produto>(){
                    new Produto(1, "Desenvolvimento de App"),
                    new Produto(2, "Desenvolvimento Web"),
                    new Produto(3, "Integração com SAP"),
                    new Produto(4, "Integração com Mastersaf"),
                    new Produto(5, "Suporte Nível Especialista"),
                    new Produto(6, "Solução Tributária")
                });

            builder.Entity<Cliente>()
                .HasData(new List<Cliente>(){
                        new Cliente(1, "josé", "coca", DateTime.Now, DateTime.Now, "12121-2121", "a@asdas.com", "jsahdausi", 1),
                    });

           
        }
    }
}