using Escola.Domain.DTO;
using System;

namespace Escola.Domain.Models
{
	public class Boletim
	{

		public int Id { get; internal set; }
		public String Semestre { get; set; }

		public int Faltas { get; set; }

		public Guid AlunoId { get; set; }
		public virtual Aluno Aluno { get; set; }

        public IList<NotasMateria> Notas { get; set; }
		

		public Boletim()
		{ }
		public Boletim(BoletimDTO boletim)
		{
			Id = boletim.Id;
			Semestre = boletim.Semestre;
			Faltas = boletim.Faltas;
			AlunoId = boletim.AlunoId;
		}

		public void Update(BoletimDTO boletim)
		{
			Semestre = boletim.Semestre;
			Faltas = boletim.Faltas;
			AlunoId = boletim.AlunoId;
		}
	}
}
