using Escola.Domain.Interfaces.Repositories;
using Escola.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Escola.Infra.DataBase.Repositories
{
    public class MateriaRepositorio : IMateriaRepositorio
    {
        private readonly EscolaDBContexto _dBContexto;
        public MateriaRepositorio(EscolaDBContexto dBContexto)
        {
            _dBContexto = dBContexto;
        }

        public void Atualizar(Materia materia)
        {
            _dBContexto.Materias.Update(materia);
            _dBContexto.SaveChanges();
        }

        public void Excluir(Materia materia)
        {
            _dBContexto.Materias.Remove(materia);
            _dBContexto.SaveChanges();
        }

        public void Inserir(Materia materia)
        {
            _dBContexto.Materias.Add(materia);
            _dBContexto.SaveChanges();
        }

        public Materia ObterPorId(int id)
        {
            return _dBContexto.Materias.Find(id);
        }

        public List<Materia> ObterPorNome(string nome)
        {
            return _dBContexto.Materias.Where(materia => materia.Nome == nome).ToList();
        }

        public IList<Materia> ObterTodos(Paginacao paginacao)
        {
            return _dBContexto.Materias.Take(paginacao.Take).Skip(paginacao.Skip).ToList();
        }

        public int ObterTotal()
        {
            return _dBContexto.Materias.Count();
        }
    }
}
