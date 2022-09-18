using Escola.Domain.DTO;
using System;

namespace Escola.Domain.Models
{
	public class Materia
   {
		public int Id { get; internal set; }

		public string Nome { get; set; }

		public string Professor { get; set; }

        public virtual List<NotasMateria> NotasMaterias { get; set; }

        public Materia()
        { }
        public Materia(MateriaDTO materia)
        {
            Id = materia.Id;
            Nome = materia.Nome;
            Professor = materia.Professor;
        }

        public void Update(MateriaDTO materia)
        {
            Nome = materia.Nome;
            Professor = materia.Professor;
        }
    }
}