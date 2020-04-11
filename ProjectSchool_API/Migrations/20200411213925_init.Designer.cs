﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProjectSchool_API.Data;

namespace ProjectSchool_API.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20200411213925_init")]
    partial class init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity("ProjectSchool_API.Models.Aluno", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("DataNasc");

                    b.Property<string>("Nome");

                    b.Property<int>("ProfessorId");

                    b.Property<string>("SobreNome");

                    b.HasKey("Id");

                    b.HasIndex("ProfessorId");

                    b.ToTable("Alunos");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            DataNasc = "01/01/2000",
                            Nome = "Maria",
                            ProfessorId = 1,
                            SobreNome = "Oliveira"
                        },
                        new
                        {
                            Id = 2,
                            DataNasc = "20/01/1990",
                            Nome = "João",
                            ProfessorId = 2,
                            SobreNome = "Paulo"
                        },
                        new
                        {
                            Id = 3,
                            DataNasc = "25/06/1981",
                            Nome = "Alex",
                            ProfessorId = 3,
                            SobreNome = "Ferraz"
                        });
                });

            modelBuilder.Entity("ProjectSchool_API.Models.Professor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Nome");

                    b.HasKey("Id");

                    b.ToTable("Professores");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Nome = "Paulo"
                        },
                        new
                        {
                            Id = 2,
                            Nome = "Vinicius"
                        },
                        new
                        {
                            Id = 3,
                            Nome = "Alice"
                        });
                });

            modelBuilder.Entity("ProjectSchool_API.Models.Aluno", b =>
                {
                    b.HasOne("ProjectSchool_API.Models.Professor", "Professor")
                        .WithMany("Alunos")
                        .HasForeignKey("ProfessorId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
