using Escola.Domain.DTO;
using Escola.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Escola.Api.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class NotasMateriaController : ControllerBase
    {
        private readonly INotasMateriaServico _notasMateriaServico;

        public NotasMateriaController(INotasMateriaServico notasMateriaServico)
        {
            _notasMateriaServico = notasMateriaServico;
        }

        // GET: api/<NotasMateriaController>
       
        
        [HttpGet("/api/alunos/{idAluno}/boletins/{idBoletim}/NotasMateria")]
        public IActionResult ObterPoId([FromRoute] Guid idAluno,[FromRoute] int idBoletim)
        {
            return Ok(_notasMateriaServico.ObterPorBoletim(idAluno,idBoletim));

        }

        // GET api/<NotasMateriaController>/5
        [HttpGet("{id}")]
        public IActionResult ObterPorId([FromRoute] int id)
        {
            return Ok(_notasMateriaServico.ObterPorId(id));
        }


        // POST api/<NotasMateriaController>
        [HttpPost]
        public IActionResult Post([FromBody] NotaDTO nota)
        {
            _notasMateriaServico.Inserir(nota);

            return StatusCode(StatusCodes.Status201Created);

        }

        // PUT api/<NotasMateriaController>/5
        [HttpPut("{id}")]
        public IActionResult Put([FromRoute] int id, [FromBody] NotaDTO nota)
        {
        _notasMateriaServico.Atualizar(id, nota);
            return Ok();
        }

        // DELETE api/<NotasMateriaController>/5
        [HttpDelete("{id}")]
        public IActionResult Deletar([FromRoute] int id)
        {
            _notasMateriaServico.Excluir(id);
            return NoContent();
        }
    }
}
