using Escola.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Escola.Infra.DataBase.Mappings
{
   public class BoletimMap : IEntityTypeConfiguration<Boletim>
    {
        public void Configure(EntityTypeBuilder<Boletim> builder)
        {
            builder.ToTable("Boletim");

            builder.HasKey(boletim => boletim.Id);

            builder.Property(boletim => boletim.Id)
                    .UseIdentityColumn()
                    .ValueGeneratedOnAdd();

            builder.Property(boletim => boletim.Semestre)
                  .HasColumnName("Semestre")
                  .HasColumnType("varchar")
                  .HasMaxLength(80);

            builder.Property(boletim => boletim.Faltas)
                 .HasColumnName("Faltas")
                 .HasColumnType("int");

            builder.HasOne(boletim => boletim.Aluno)
                   .WithMany(alunos => alunos.Boletins)
                   .HasForeignKey(boletim => boletim.AlunoId);

    }   }
}
