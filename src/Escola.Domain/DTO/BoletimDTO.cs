﻿using Escola.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Escola.Domain.DTO
{
   public class BoletimDTO
    {
        public int Id { get; internal set; }
        public String Semestre { get; set; }

        public int Faltas { get; set; }

        public Guid AlunoId { get; set; }

        public BoletimDTO()
        { }

        public BoletimDTO(Boletim boletim)
        {
            Id = boletim.Id;
            Semestre = boletim.Semestre;
            Faltas = boletim.Faltas;
            AlunoId = boletim.AlunoId;


        }
    }
}
