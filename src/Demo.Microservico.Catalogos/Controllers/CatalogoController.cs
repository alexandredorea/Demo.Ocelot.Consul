using Demo.Microservico.Catalogos.Servicos;
using Microsoft.AspNetCore.Mvc;

namespace Demo.Microservico.Catalogos.Controllers
{
    [ApiController]
    [Route("api/catalogo")]
    public class CatalogoController : ControllerBase
    {
        private readonly ICatalogoServico catalogoServico;

        public CatalogoController(ICatalogoServico catalogoServico)
        {
            this.catalogoServico = catalogoServico;
        }

        [HttpGet("obtertodos")]
        public IActionResult ObterTodos()
        {
            try
            {
                return Ok(catalogoServico.ObterTodas());
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}