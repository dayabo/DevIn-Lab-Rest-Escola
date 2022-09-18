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
    public class BoletimServico : IBoletimServico
    {
        private readonly IBoletimRepositorio _boletimRepositorio;

        public BoletimServico(IBoletimRepositorio boletimRepositorio)
        {
            _boletimRepositorio = boletimRepositorio;
        }

        public void Atualizar(int id, BoletimDTO boletim)
        {
            var boletimDB = _boletimRepositorio.ObterPorId(id);
            if (boletimDB == null)
            {
                throw new NaoExisteException("Boletim não Existente");
            }

            boletimDB.Update(boletim);
           _boletimRepositorio.Atualizar(boletimDB);
        }

        public void Excluir(int id)
        {
            var boletimDB = _boletimRepositorio.ObterPorId(id);
            if (boletimDB == null)
            {
                throw new NaoExisteException("Exclusão não pode ser feita pois boletim não existe");
            }
            _boletimRepositorio.Excluir(boletimDB);
        }

        public void Inserir(BoletimDTO boletim)
        {
            _boletimRepositorio.Inserir(new Boletim(boletim));
        }

        public BoletimDTO ObterPorId(int id)
        {
            return new BoletimDTO(_boletimRepositorio.ObterPorId(id));
        }
        public IList<BoletimDTO> ObterPorIdAluno(Guid id)
        {
           return _boletimRepositorio.ObterPorIdAluno(id).Select(boletim => new BoletimDTO(boletim)).ToList();
          
        }
       
    }
}

