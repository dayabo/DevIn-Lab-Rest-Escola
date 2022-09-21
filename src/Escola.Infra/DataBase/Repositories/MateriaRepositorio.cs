using Escola.Domain.Interfaces.Repositories;
using Escola.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Escola.Infra.DataBase.Repositories
{
    public class MateriaRepositorio : BaseRepositorio<Materia,int>, IMateriaRepositorio
    {

        public MateriaRepositorio(EscolaDBContexto contexto) : base(contexto)
        { 
        }

        public Materia ObterPorNome(string nome)
        {
            return _contexto.Materias.Where(m => m.Nome.Contains(nome)).FirstOrDefault(m => m.Nome == nome);
        }

        public bool ExisteMateria(string nome)
        {
            return _contexto.Materias.Any(materia => materia.Nome.Contains(nome));
        }
        public int ObterTotal()
        {
            return _contexto.Materias.Count();
        }
    }
}
