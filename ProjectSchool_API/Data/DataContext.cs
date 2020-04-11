using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using ProjectSchool_API.Models;

namespace ProjectSchool_API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        public DbSet<Aluno> Alunos { get; set; }
        public DbSet<Professor> Professores { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Professor>()
                .HasData(
                    new List<Professor>(){
                        new Professor() {
                            Id = 1,
                            Nome = "Paulo"
                        },
                        new Professor() {
                            Id = 2,
                            Nome = "Vinicius"
                        },
                        new Professor() {
                            Id = 3,
                            Nome = "Alice"
                        },
                    }
                );

            builder.Entity<Aluno>()
                .HasData(
                    new List<Aluno>(){
                        new Aluno() {
                            Id = 1,
                            Nome = "Maria",
                            SobreNome = "Oliveira",
                            DataNasc = "01/01/2000",
                            ProfessorId = 1
                        },
                        new Aluno() {
                            Id = 2,
                            Nome = "João",
                            SobreNome = "Paulo",
                            DataNasc = "20/01/1990",
                            ProfessorId = 2
                        },
                        new Aluno() {
                            Id = 3,
                            Nome = "Alex",
                            SobreNome = "Ferraz",
                            DataNasc = "25/06/1981",
                            ProfessorId = 3
                        },
                    }
                );
        }
    }
}