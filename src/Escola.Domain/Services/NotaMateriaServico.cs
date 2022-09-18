using Escola.Domain.DTO;
using Escola.Domain.Exceptions;
using Escola.Domain.Interfaces.Repositories;
using Escola.Domain.Interfaces.Services;
using Escola.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Escola.Domain.Services
{
   public class NotaMateriaServico : INotasMateriaServico
    {
        private readonly INotasMateriasRepositorio _notasMateriaRepositorio;

        public NotaMateriaServico(INotasMateriasRepositorio notasMateriaRepositorio)
        {
            _notasMateriaRepositorio = notasMateriaRepositorio;
        }

        public void Atualizar(int id, NotaDTO nota)
        {
            var notaDB = _notasMateriaRepositorio.ObterPorId(nota.Id);
           
            if (notaDB == null)
            {
                throw new NaoExisteException("Boletim não Existente");
            }

            notaDB.Update(nota);
          _notasMateriaRepositorio.Atualizar(notaDB);
        }

        public void Excluir(int id)
        {
            var notaDB = _notasMateriaRepositorio.ObterPorId(id);

            if (notaDB == null)
            {
                throw new NaoExisteException("Exclusão não pode ser feita pois nota ainda não existe");
            }
            
           _notasMateriaRepositorio.Excluir(notaDB);
        }

        public void Inserir(NotaDTO nota)
        {
           _notasMateriaRepositorio.Inserir(new NotasMateria(nota));
        }

        public NotaDTO ObterPorId(int id)
        {
            return new NotaDTO(_notasMateriaRepositorio.ObterPorId(id));
        }

        public IList<NotaDTO> ObterPorBoletim(Guid idAluno, int idBoletim)
        {
            return _notasMateriaRepositorio.ObterPorBoletim(idAluno, idBoletim).Select(notasMateria => new NotaDTO(notasMateria)).ToList();

        }
    }
}
