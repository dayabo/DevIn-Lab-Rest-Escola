using Escola.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Escola.Domain.Interfaces.Repositories
{
   public interface IBoletimRepositorio
    {
        Boletim ObterPorId(int id);
        IList<Boletim> ObterPorIdAluno(Guid id);
        void Inserir(Boletim boletim);
        void Excluir(Boletim boletim);
        void Atualizar(Boletim boletim);
    }
}

   