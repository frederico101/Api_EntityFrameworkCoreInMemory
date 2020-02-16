using API.Data;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProdutosController : ControllerBase
    {
        private readonly IProdutoRepositorio _repositorio;
        public ProdutosController(IProdutoRepositorio repositorio)
        {
            _repositorio = repositorio;
        }
        [HttpPost]
        public IActionResult Criar([FromBody] Produto produto)
        {
            _repositorio.Inserir(produto);
            return Ok();
        }
        [HttpGet]
        public IActionResult Obter()
        {
            var lista = _repositorio.Obter();
            return Ok(lista);
        }
        [HttpGet("{id}")]
        public IActionResult Obter(int id)
        {   
            var produto = _repositorio.Obter(id);
            if(produto == null) return NotFound();
            return Ok(produto);
        }
        [HttpPut]
        public IActionResult Atualizar([FromBody] Produto produto)
        {
            var prod = _repositorio.Obter(produto.Id);
            if(prod.Id == null) return NotFound();
            _repositorio.Editar(produto);
            return Ok(produto);
        }
        [HttpDelete("{id}")]
        public IActionResult Apagar(int id)
        {
            var prod = _repositorio.Obter(id);
            if(prod == null) return NotFound();
            _repositorio.Excluir(prod);
            return Ok();
        }
    }
}
