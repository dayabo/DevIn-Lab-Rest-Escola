using Escola.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Escola.Domain.DTO
{
   public class NotaDTO
    {
        public int Id { get; internal set; }

        public float Nota { get; set; }

        public int MateriaId { get; set; }
      
        public int BoletimId { get; set; }

        public NotaDTO()
        { }
        public NotaDTO(NotasMateria nota)
        {
            Id = nota.Id;
            Nota = nota.Nota;
            MateriaId = nota.MateriaId;
            BoletimId = nota.BoletimId;
        }
    }

}
