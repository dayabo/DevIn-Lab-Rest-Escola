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
   public class MateriaMap : IEntityTypeConfiguration<Materia>
    {
        public void Configure(EntityTypeBuilder<Materia> builder)
        {
            builder.ToTable("Materia");

            builder.HasKey(materia => materia.Id);

            builder.Property(materia => materia.Id)
                    .UseIdentityColumn()
                    .ValueGeneratedOnAdd();

            builder.Property(materia => materia.Nome)
                   .HasColumnName("Nome")
                   .HasColumnType("varchar")
                   .HasMaxLength(80);

            builder.Property(materia => materia.Professor)
                  .HasColumnName("Professor")
                  .HasColumnType("varchar")
                  .HasMaxLength(150);

         }
    }
}
