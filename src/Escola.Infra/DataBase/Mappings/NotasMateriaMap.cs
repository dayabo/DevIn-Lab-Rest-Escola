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
   public class NotasMateriaMap : IEntityTypeConfiguration<NotasMateria>
    {
        public void Configure(EntityTypeBuilder<NotasMateria> builder)
        {
            builder.ToTable("Notas Materias");

            builder.HasKey(notasMateria => notasMateria.Id);

            builder.Property(notasMateria => notasMateria.Id)
                    .UseIdentityColumn()
                    .ValueGeneratedOnAdd();

            builder.Property(notasMateria => notasMateria.Nota)
                  .HasColumnName("Nota")
                  .HasColumnType("float");

            builder.HasOne(notasMateria => notasMateria.Materia)
                   .WithMany(materia => materia.NotasMaterias)
                   .HasForeignKey(notasMateria => notasMateria.MateriaId);

            builder.HasOne(notasMateria => notasMateria.Boletim)
                  .WithMany(boletim => boletim.Notas)
                  .HasForeignKey(notasMateria => notasMateria.BoletimId);
          
         }
    }
}
