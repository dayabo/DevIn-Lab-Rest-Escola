using Escola.Domain.DTO;
using Escola.Domain.Interfaces.Services;
using Escola.Domain.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Escola.Api.Controllers
{
    [ApiController]
    [ApiVersion("2.0")]
    [Route("api/v{version:apiVersion}/materia")]
   
    public class MateriaV2Controller : ControllerBase
    {

        private readonly IMateriaServico _materiaServico;

        public MateriaV2Controller(IMateriaServico materiaServico)
        {
            _materiaServico = materiaServico;
        }

        [MapToApiVersion("2.0")]
        [HttpGet]
        public IActionResult ObterTodos([FromQuery] string nome, int skip, int take)
        {
            var paginacao = new Paginacao(take, skip);
            var totalRegistros = _materiaServico.ObterTotal();

            if (!string.IsNullOrEmpty(nome))
            {
                return Ok(new MateriaV2DTO(_materiaServico.ObterPorNome(nome)));
            }

            Response.Headers.Add("x-Paginacao-TotalDeRegistros", totalRegistros.ToString());

            return Ok(_materiaServico.ObterTodos(paginacao).Select(materiaDTO => new MateriaV2DTO(materiaDTO)));
        }

        [MapToApiVersion("2.0")]
        [HttpGet("{id}")]
       
        public IActionResult ObterPorId([FromRoute] int id)
        { 
            return Ok(new MateriaV2DTO(_materiaServico.ObterPorId(id)));
        }

        [MapToApiVersion("2.0")]
        [HttpPost]
        public IActionResult Post([FromBody] MateriaV2DTO materia)
        {
            _materiaServico.Inserir(new MateriaDTO(materia));
         
            return StatusCode(StatusCodes.Status201Created);

        }

        [MapToApiVersion("2.0")]
        [HttpPut("{id}")]
        public IActionResult Put([FromRoute] int id, [FromBody] MateriaV2DTO materia)
        {
            _materiaServico.Atualizar(id,(new MateriaDTO( materia)));
            return Ok();
        }

        [MapToApiVersion("2.0")]
        [HttpDelete("{id}")]
        public IActionResult Deletar([FromRoute] int id)
        {
            _materiaServico.Excluir(id);
            return  NoContent();
        }
    }
}
