using Escola.Domain.DTO;
using Escola.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Escola.Domain.Interfaces.Services
{
    public interface IMateriaServico
    {
        IList<MateriaDTO> ObterTodos(Paginacao paginacao);
        MateriaDTO ObterPorId(int id);
        IList<MateriaDTO> ObterPorNome(string nome);
        void Inserir(MateriaDTO materia);
        void Excluir(int id);
        void Atualizar(int id, MateriaDTO materia);
        int ObterTotal();
    }
}
