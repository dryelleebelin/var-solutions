using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using WebApiPessoa.Repository.Models;

namespace WebApiPessoa.Repository
{
    //representação do banco de dados
    public class PessoaContext : DbContext  //PessoaContext está herdando o que tem dentro de DbContext
    {
        public PessoaContext(DbContextOptions<PessoaContext> options) : base(options) { }

        public DbSet<TUsuario> Usuarios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TUsuario>().ToTable("tUsuario");
        }
    }
}