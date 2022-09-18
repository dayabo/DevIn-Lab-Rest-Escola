﻿// <auto-generated />
using System;
using Escola.Infra.DataBase;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Escola.Infra.Migrations
{
    [DbContext(typeof(EscolaDBContexto))]
    partial class EscolaDBContextoModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Escola.Domain.Models.Aluno", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("ID");

                    b.Property<DateTime>("DataNascimento")
                        .HasColumnType("DATE")
                        .HasColumnName("DATA_NASCIMENTO");

                    b.Property<string>("Email")
                        .HasMaxLength(200)
                        .HasColumnType("VARCHAR(200)")
                        .HasColumnName("EMAIL");

                    b.Property<int>("Matricula")
                        .HasColumnType("int")
                        .HasColumnName("Matricula");

                    b.Property<string>("Nome")
                        .HasMaxLength(80)
                        .HasColumnType("VARCHAR(80)")
                        .HasColumnName("NOME");

                    b.Property<string>("Sobrenome")
                        .HasMaxLength(150)
                        .HasColumnType("VARCHAR(150)")
                        .HasColumnName("SOBRENOME");

                    b.HasKey("Id")
                        .HasName("PK_AlunoID");

                    b.HasIndex("Matricula")
                        .IsUnique();

                    b.ToTable("ALUNO", (string)null);
                });

            modelBuilder.Entity("Escola.Domain.Models.Boletim", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<Guid>("AlunoId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Faltas")
                        .HasColumnType("int")
                        .HasColumnName("Faltas");

                    b.Property<string>("Semestre")
                        .HasMaxLength(80)
                        .HasColumnType("varchar(80)")
                        .HasColumnName("Semestre");

                    b.HasKey("Id");

                    b.HasIndex("AlunoId");

                    b.ToTable("Boletim", (string)null);
                });

            modelBuilder.Entity("Escola.Domain.Models.Materia", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Nome")
                        .HasMaxLength(80)
                        .HasColumnType("varchar(80)")
                        .HasColumnName("Nome");

                    b.Property<string>("Professor")
                        .HasMaxLength(150)
                        .HasColumnType("varchar(150)")
                        .HasColumnName("Professor");

                    b.HasKey("Id");

                    b.ToTable("Materia", (string)null);
                });

            modelBuilder.Entity("Escola.Domain.Models.NotasMateria", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("BoletimId")
                        .HasColumnType("int");

                    b.Property<int>("MateriaId")
                        .HasColumnType("int");

                    b.Property<double>("Nota")
                        .HasColumnType("float")
                        .HasColumnName("Nota");

                    b.HasKey("Id");

                    b.HasIndex("BoletimId");

                    b.HasIndex("MateriaId");

                    b.ToTable("Notas Materias", (string)null);
                });

            modelBuilder.Entity("Escola.Domain.Models.Boletim", b =>
                {
                    b.HasOne("Escola.Domain.Models.Aluno", "Aluno")
                        .WithMany("Boletins")
                        .HasForeignKey("AlunoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Aluno");
                });

            modelBuilder.Entity("Escola.Domain.Models.NotasMateria", b =>
                {
                    b.HasOne("Escola.Domain.Models.Boletim", "Boletim")
                        .WithMany("Notas")
                        .HasForeignKey("BoletimId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Escola.Domain.Models.Materia", "Materia")
                        .WithMany("NotasMaterias")
                        .HasForeignKey("MateriaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Boletim");

                    b.Navigation("Materia");
                });

            modelBuilder.Entity("Escola.Domain.Models.Aluno", b =>
                {
                    b.Navigation("Boletins");
                });

            modelBuilder.Entity("Escola.Domain.Models.Boletim", b =>
                {
                    b.Navigation("Notas");
                });

            modelBuilder.Entity("Escola.Domain.Models.Materia", b =>
                {
                    b.Navigation("NotasMaterias");
                });
#pragma warning restore 612, 618
        }
    }
}
