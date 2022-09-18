using Escola.Domain.Interfaces.Repositories;
using Escola.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Escola.Infra.DataBase.Repositories
{
    public class BoletimRepositorio : IBoletimRepositorio
    {
        private readonly EscolaDBContexto _dBContexto;
        public BoletimRepositorio(EscolaDBContexto dBContexto)
        {
            _dBContexto = dBContexto;
        }
        public void Atualizar(Boletim boletim)
        {
            _dBContexto.Boletins.Update(boletim);
            _dBContexto.SaveChanges();
        }

        public void Excluir(Boletim boletim)
        {
            _dBContexto.Boletins.Remove(boletim);
            _dBContexto.SaveChanges();
        }
        

        public void Inserir(Boletim boletim)
        {
            _dBContexto.Boletins.Add(boletim);
            _dBContexto.SaveChanges();
        }

        public Boletim ObterPorId(int id)
        {
            return _dBContexto.Boletins.Find(id);
        }

        
        public IList<Boletim> ObterPorIdAluno(Guid id)
        {
            return _dBContexto.Boletins.Where(boletim => boletim.AlunoId == id).ToList();

        }
    }
}
