using Escola.Domain.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Escola.Domain.Models
{
    public class NotasMateria
    {
        public int Id { get; internal set; }

        public float Nota { get; set; }

        public int MateriaId { get; set; }
        public virtual Materia Materia { get; set; }

        public int BoletimId { get; set; }
        public virtual Boletim Boletim { get; set; }


        public NotasMateria()
        { }

        public NotasMateria(NotaDTO nota)
        {
            Id = nota.Id;
            Nota = nota.Nota;
            MateriaId = nota.MateriaId;
            BoletimId = nota.BoletimId;
      
        }

        public void Update(NotaDTO nota)
        {
            Nota = nota.Nota;
            MateriaId = nota.MateriaId;
            BoletimId = nota.BoletimId;
        }

    }
}
