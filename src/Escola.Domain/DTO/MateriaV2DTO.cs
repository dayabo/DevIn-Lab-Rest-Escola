using Escola.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Escola.Domain.DTO
{
    public class MateriaV2DTO
    {
        public int Id { get; internal set; }

        public string Disciplina { get; set; }

        public string Professor { get; set; }

        public MateriaV2DTO()
        { }

        public MateriaV2DTO (MateriaDTO materia)
        {
            Id = materia.Id;
            Disciplina = materia.Nome;
            Professor = materia.Professor;
        }
        

    }
}
