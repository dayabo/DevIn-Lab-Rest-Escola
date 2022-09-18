using Escola.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Escola.Domain.Interfaces.Repositories
{
      public interface INotasMateriasRepositorio
    {
        IList<NotasMateria> ObterPorBoletim(Guid idAluno, int idBoletim);
        NotasMateria ObterPorId(int id);
        void Inserir(NotasMateria notasMateria);
        void Excluir(NotasMateria notasMateria);
        void Atualizar(NotasMateria notasMateria);
    }
}
