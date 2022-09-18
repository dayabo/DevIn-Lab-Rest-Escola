using Escola.Domain.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Escola.Domain.Interfaces.Services
{
    public interface INotasMateriaServico
    {
        IList<NotaDTO> ObterPorBoletim(Guid idAluno, int idBoletim);
        NotaDTO ObterPorId(int id);
        void Inserir(NotaDTO nota);
        void Excluir(int id);
        void Atualizar(int id, NotaDTO nota);

    }
}
