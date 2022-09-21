using Escola.Domain.DTO;
using Escola.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Escola.Api.Controllers
{
 
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/notasMateria")]
    public class NotasMateriaController : ControllerBase
    {
        private readonly INotasMateriaServico _notasMateriaServico;

        public NotasMateriaController(INotasMateriaServico notasMateriaServico)
        {
            _notasMateriaServico = notasMateriaServico;
        }




        [MapToApiVersion("1.0")]
        [HttpGet("/api/alunos/{idAluno}/boletins/{idBoletim}/NotasMateria")]
        public IActionResult ObterPoId([FromRoute] Guid idAluno,[FromRoute] int idBoletim)
        {
            return Ok(_notasMateriaServico.ObterPorBoletim(idAluno,idBoletim));

        }


        [MapToApiVersion("1.0")]
        [HttpGet("{id}")]
        public IActionResult ObterPorId([FromRoute] int id)
        {
            return Ok(_notasMateriaServico.ObterPorId(id));
        }



        [MapToApiVersion("1.0")]
        [HttpPost]
        public IActionResult Post([FromBody] NotaDTO nota)
        {
            _notasMateriaServico.Inserir(nota);

            return StatusCode(StatusCodes.Status201Created);

        }


        [MapToApiVersion("1.0")]
        [HttpPut("{id}")]
        public IActionResult Put([FromRoute] int id, [FromBody] NotaDTO nota)
        {
        _notasMateriaServico.Atualizar(id, nota);
            return Ok();
        }


        [MapToApiVersion("1.0")]
        [HttpDelete("{id}")]
        public IActionResult Deletar([FromRoute] int id)
        {
            _notasMateriaServico.Excluir(id);
            return NoContent();
        }
    }
}
