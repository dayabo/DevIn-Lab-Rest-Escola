using Escola.Domain.DTO;
using Escola.Domain.Interfaces.Services;
using Escola.Domain.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Escola.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MateriaController : ControllerBase
    {

        private readonly IMateriaServico _materiaServico;

        public MateriaController(IMateriaServico materiaServico)
        {
            _materiaServico = materiaServico;
        }

      
        [HttpGet]
        public IActionResult ObterTodos([FromQuery] string nome, int skip, int take)
        {
            var paginacao = new Paginacao(take, skip);
            var totalRegistros = _materiaServico.ObterTotal();

            if (!string.IsNullOrEmpty(nome))
            {
                return Ok(_materiaServico.ObterPorNome(nome));
            }

            Response.Headers.Add("x-Paginacao-TotalDeRegistros", totalRegistros.ToString());

            return Ok(_materiaServico.ObterTodos(paginacao));
        }
        
        [HttpGet("{id}")]
       
        public IActionResult ObterPorId([FromRoute] int id)
        { 
            return Ok(_materiaServico.ObterPorId(id));
        }


        // POST api/<Materia>
        [HttpPost]
        public IActionResult Post([FromBody] MateriaDTO materia)
        {
            _materiaServico.Inserir(materia);
         
            return StatusCode(StatusCodes.Status201Created);

        }

        
        [HttpPut("{id}")]
        public IActionResult Put([FromRoute] int id, [FromBody] MateriaDTO materia)
        {
            _materiaServico.Atualizar(id,materia);
            return Ok();
        }

      
        [HttpDelete("{id}")]
        public IActionResult Deletar([FromRoute] int id)
        {
            _materiaServico.Excluir(id);
            return  NoContent();
        }
    }
}
