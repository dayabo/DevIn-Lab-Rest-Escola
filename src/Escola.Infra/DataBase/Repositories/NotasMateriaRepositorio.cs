using Escola.Domain.Interfaces.Repositories;
using Escola.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Escola.Infra.DataBase.Repositories
{
    public class NotasMateriaRepositorio : BaseRepositorio<NotasMateria, int>, INotasMateriasRepositorio
    {
       
        public NotasMateriaRepositorio(EscolaDBContexto contexto) : base(contexto)
        {  
        }
     
        public IList<NotasMateria> ObterPorBoletim(Guid idAluno, int idBoletim)
        {
            return _contexto.NotasMaterias.Where(notasMateria => notasMateria.Boletim.AlunoId == idAluno && notasMateria.BoletimId == idBoletim).ToList();
         }
    }
}
