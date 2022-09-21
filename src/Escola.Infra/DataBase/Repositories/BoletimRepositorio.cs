using Escola.Domain.Interfaces.Repositories;
using Escola.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Escola.Infra.DataBase.Repositories
{
    public class BoletimRepositorio : BaseRepositorio<Boletim, int>, IBoletimRepositorio
    {
       
        public BoletimRepositorio(EscolaDBContexto contexto) : base(contexto)
        {
        }
       
        
        public IList<Boletim> ObterPorIdAluno(Guid id)
        {
            return _contexto.Boletins.Where(boletim => boletim.AlunoId == id).ToList();
        }
    }
}
