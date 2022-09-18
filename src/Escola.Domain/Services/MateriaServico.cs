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
    public class MateriaServico : IMateriaServico
    {
        private readonly IMateriaRepositorio _materiaRepositorio;

        public MateriaServico(IMateriaRepositorio materiaRepositorio)
        {
            _materiaRepositorio = materiaRepositorio;
        }

        public void Atualizar(int id, MateriaDTO materia)
        {
            var materiaDB = _materiaRepositorio.ObterPorId(id);
            if (materiaDB == null)
            {
               throw new NaoExisteException("Matéria não Existente");
            }
            
            materiaDB.Update(materia);

            _materiaRepositorio.Atualizar(materiaDB);
        }

        public void Excluir(int id)
        {
            var materiaDB = _materiaRepositorio.ObterPorId(id);
            _materiaRepositorio.Excluir(materiaDB);
        }

        public void Inserir(MateriaDTO materia)
        {
           var jaExiste = _materiaRepositorio.ObterPorNome(materia.Nome);
            if (jaExiste.Count > 0)
                throw new DuplicadoException("Matéria já existe");


            _materiaRepositorio.Inserir(new Materia(materia));
           
        }

        public MateriaDTO ObterPorId(int id)
        {
           return new MateriaDTO( _materiaRepositorio.ObterPorId(id));
        }

        public IList<MateriaDTO> ObterPorNome(string nome)
        {
            return _materiaRepositorio.ObterPorNome(nome).Select(materia => new MateriaDTO(materia)).ToList();
        }

        public IList<MateriaDTO> ObterTodos(Paginacao paginacao)
        {
            return _materiaRepositorio.ObterTodos(paginacao).Select(materia => new MateriaDTO(materia)).ToList();
        }
        public int ObterTotal()
        {
            return _materiaRepositorio.ObterTotal();
        }
    }
}
