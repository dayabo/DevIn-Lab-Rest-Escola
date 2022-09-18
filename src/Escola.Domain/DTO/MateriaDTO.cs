﻿using Escola.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Escola.Domain.DTO
{
    public class MateriaDTO
    {
        public int Id { get; internal set; }

        public string Nome { get; set; }

        public string Professor { get; set; }

        public MateriaDTO()
        {

        }
        public MateriaDTO (Materia materia)
        {
            Id = materia.Id;
            Nome = materia.Nome;
            Professor = materia.Professor;
        }   
    }
}
