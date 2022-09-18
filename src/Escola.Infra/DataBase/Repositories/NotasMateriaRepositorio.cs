using Escola.Domain.Interfaces.Repositories;
using Escola.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Escola.Infra.DataBase.Repositories
{
    public class NotasMateriaRepositorio : INotasMateriasRepositorio
    {
        private readonly EscolaDBContexto _dBContexto;
        public NotasMateriaRepositorio(EscolaDBContexto dBContexto)
        {
            _dBContexto = dBContexto;
        }
        public void Atualizar(NotasMateria notasMateria)
        {
            _dBContexto.NotasMaterias.Update(notasMateria);
            _dBContexto.SaveChanges();
        }

        public void Excluir(NotasMateria notasMateria)
        {
            _dBContexto.NotasMaterias.Remove(notasMateria);
            _dBContexto.SaveChanges();
        }

        public void Inserir(NotasMateria notasMateria)
        {
            _dBContexto.NotasMaterias.Add(notasMateria);
            _dBContexto.SaveChanges();
        }

        public NotasMateria ObterPorId(int id)
        {
            return _dBContexto.NotasMaterias.Find(id);
        }

        public IList<NotasMateria> ObterPorBoletim(Guid idAluno, int idBoletim)
        {
            return _dBContexto.NotasMaterias.Where(notasMateria => notasMateria.Boletim.AlunoId == idAluno && notasMateria.BoletimId == idBoletim).ToList();

        }
    }
}
