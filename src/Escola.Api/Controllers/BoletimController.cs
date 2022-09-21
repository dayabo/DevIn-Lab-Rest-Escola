using Escola.Domain.DTO;
using Escola.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Escola.Api.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/boletim")]
    public class BoletimController : ControllerBase
    {
        private readonly IBoletimServico _boletimServico;

        public BoletimController(IBoletimServico boletimServico)
        {
            _boletimServico = boletimServico;
        }

        [MapToApiVersion("1.0")]
        [HttpGet("/api/alunos/{{idAluno}}/boletins")]
        public IActionResult ObterPoIdAluno([FromRoute] Guid idAluno)
        {
            return Ok(_boletimServico.ObterPorIdAluno(idAluno));
           
        }

        [MapToApiVersion("1.0")]
        [HttpGet("{id}")]
        public IActionResult ObterPorId([FromRoute] int id)
        {
            return Ok(_boletimServico.ObterPorId(id));
        }

        [MapToApiVersion("1.0")]
        [HttpPost]
        public IActionResult Post([FromBody] BoletimDTO boletim)
        {
           _boletimServico.Inserir(boletim);

            return StatusCode(StatusCodes.Status201Created);
        }

        [MapToApiVersion("1.0")]
        [HttpPut("{id}")]
        public IActionResult Put([FromRoute] int id, [FromBody] BoletimDTO boletim)
        {
            _boletimServico.Atualizar(id, boletim);
            return Ok();
        }

        [MapToApiVersion("1.0")]
        [HttpDelete("{id}")]
        public IActionResult Deletar([FromRoute] int id)
        {
            _boletimServico.Excluir(id);
            return NoContent();
        }
    

    }
}
