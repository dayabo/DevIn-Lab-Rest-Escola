using Escola.Api.Config;
using Escola.Domain.DTO;
using Escola.Domain.Interfaces.Services;
using Escola.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Escola.Api.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/materias")]
    public class MateriasController : ControllerBase
    {

        private readonly IMateriaServico _materiaServico;
      
        private readonly CacheService<MateriaDTO> _materiaCacheId;
        private readonly CacheService<MateriaDTO> _materiaCacheNome;

        public MateriasController(IMateriaServico materiaServico,CacheService<MateriaDTO> materiaCacheId, CacheService<MateriaDTO> materiaCacheNome)
        {
            materiaCacheId.Config("materiaId", new TimeSpan(0, 2, 0));
            materiaCacheNome.Config("materiaNome", new TimeSpan(0, 2, 0));
            _materiaCacheId = materiaCacheId;
            _materiaCacheNome = materiaCacheNome;
            _materiaServico = materiaServico;
           
        }

        [MapToApiVersion("1.0")]
        [HttpGet]
        public IActionResult ObterTodos([FromQuery] string nome, int skip, int take)
        {
            var paginacao = new Paginacao(take, skip);
            var totalRegistros = _materiaServico.ObterTotal();


            var uriBase = $"{Request.Scheme}://{Request.Host}";

            if (!string.IsNullOrEmpty(nome))
            { 

                if (!_materiaCacheNome.TryGetValue(nome, out MateriaDTO materiaNome))
                {
                    materiaNome = _materiaServico.ObterPorNome(nome);

                    _materiaCacheNome.Set(nome, materiaNome);

                    

                    materiaNome.Links = GetHateoasMateriaPorNome(uriBase, materiaNome,nome);

                 }
          
                return Ok(materiaNome);
            }

            Response.Headers.Add("x-Paginacao-TotalDeRegistros", totalRegistros.ToString());

            var materiaEnvelopada = new BaseDTO<List<MateriaDTO>>()
            {
                Data = _materiaServico.ObterTodos(paginacao).ToList(),
                Links = GetHateoasMateriaLista(uriBase, take, skip,totalRegistros)
            };
            foreach( var materia in materiaEnvelopada.Data)
            {
                materia.Links = GetHateoasMateria(uriBase, materia);
            }
            return Ok(materiaEnvelopada);
        }


        [MapToApiVersion("1.0")]
        [HttpGet("{id}")]
       
        public IActionResult ObterPorId([FromRoute] int id)
        {
            
            MateriaDTO materia;

            if(!_materiaCacheId.TryGetValue($"{id}", out materia))
            {
                materia = _materiaServico.ObterPorId(id);

                var uriBase = $"{Request.Scheme}://{Request.Host}";

                materia.Links = GetHateoasMateria(uriBase, materia);

                _materiaCacheId.Set(id.ToString(), materia);

              
            }
       
            return Ok(materia);
        }


        [MapToApiVersion("1.0")]
        [HttpPost]
        public IActionResult Post([FromBody] MateriaDTO materia)
        {
            _materiaServico.Inserir(materia);
         
            return StatusCode(StatusCodes.Status201Created);

        }

        [MapToApiVersion("1.0")]
        [HttpPut("{id}")]
        public IActionResult Put([FromRoute] int id, [FromBody] MateriaDTO materia)
        {
            _materiaServico.Atualizar(id,materia);

         _materiaCacheId.Remove($"{id}");

         _materiaCacheNome.Remove(materia.Nome);
            return Ok();
        }

        [MapToApiVersion("1.0")]
        [HttpDelete("{id}")]
        public IActionResult Deletar([FromRoute] int id)
        {
            _materiaServico.Excluir(id);


            _materiaCacheId.Remove($"{id}");

            return  NoContent();
        }

        private List<HateoasDTO> GetHateoasMateria(string url, MateriaDTO materiaTDO)
        {
           return new List<HateoasDTO>()
            {
                new HateoasDTO()
                {
                 Rel = "self",
                 Type = "GET",
                 URI = $"{url}/api/v1/materias/{materiaTDO.Id}"
                 },
                  new HateoasDTO()
                  {
                   Rel = "materia",
                   Type = "PUT",
                   URI = $"{url}/api/v1/materias/{materiaTDO.Id}"
                   },
                   new HateoasDTO()
                  {
                   Rel = "materia",
                   Type = "DELETE",
                   URI = $"{url}/api/v1/materias/{materiaTDO.Id}"
                   },
                    new HateoasDTO()
                    {
                     Rel = "materiaPorNome",
                     Type = "Get",
                     URI= $"{url}/api/v1/materias?nome={materiaTDO.Nome}"
                    },

            };
          
         }

        private List<HateoasDTO> GetHateoasMateriaPorNome(string url, MateriaDTO materiaTDO, string nome)
        {
            var hateoas = new List<HateoasDTO>()
            {
                new HateoasDTO()
                {
                 Rel = "materiaPorNome",
                 Type = "Get",
                 URI= $"{url}/api/v1/materias?nome={nome}"
                }
 
            };
           
            return hateoas;
        }

        private List<HateoasDTO> GetHateoasMateriaLista(string url, int take, int skip, int total)
            {
                var lista = new List<HateoasDTO>()
               {
                  new HateoasDTO()
                   {
                     Rel = "self",
                     Type = "GET",
                     URI = $"{url}/api/v1/materias?skip={skip}&take={take}"
                    
                   },
                   new HateoasDTO()
                   {
                     Rel = "materia",
                     Type = "POST",
                     URI = $"{url}/api/v1/materias"
                   },

                 };

                var razao = take - skip;
                if(skip != 0)
                {
                 var newSkip = skip - razao;

                 if (newSkip < 0)
                    newSkip = 0;

                 lista.Add(new HateoasDTO() 
                 {
                    Rel = "Prev",
                    Type = "GET",
                    URI = $"{url}/api/v1/materias?skip={newSkip}&take={take - razao}"

                 });

                 }

               if (take < total)
              {
                lista.Add(new HateoasDTO()
                {
                    Rel = "Next",
                    Type = "GET",
                    URI = $"{url}/api/v1/materias?skip={skip + razao}&take={take + razao}"

                  });

                }
              return lista;

            }
    }
}
