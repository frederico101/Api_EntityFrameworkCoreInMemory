using API.Data;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{

    // [Route ("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class ProdutosController : ControllerBase
    {
        private readonly IProdutoRepositorio _repositorio;
        public ProdutosController (IProdutoRepositorio repositorio)
        {
            _repositorio = repositorio;
        }

        [Route ("")]
        // [ApiVersion ("1.0")]
        [ResponseCache (Duration = 60)]
        public IActionResult Test () => Ok ("Fine");

        [HttpPost]
        //  [ApiVersion ("1.0")]
        [ResponseCache (Duration = 60)]
        [Route ("Criar")]
        public IActionResult Criar ([FromBody] Produto produto)
        {
            if (produto.Codigo == "")
                return BadRequest ("Codigo do produto não informado");

            if (string.IsNullOrEmpty (produto.Descricao))
                return BadRequest ("Descrição do produto não informada");

            _repositorio.Inserir (produto);
            return Created (nameof (Criar), produto);
        }

        [HttpGet]
        [Route ("Obter")]
        //  [ApiVersion ("1.0")]
        [ResponseCache (Duration = 60)]
        public IActionResult Obter ()
        {
            var lista = _repositorio.Obter ();
            return Ok (lista);
        }

        [HttpGet ("{id}")]
        [Route ("ObterPorId")]
        // [ApiVersion ("1.0")]
        [ResponseCache (Duration = 60)]
        public IActionResult ObterPoId (int id)
        {
            var produto = _repositorio.Obter (id);
            if (produto == null) return NotFound ();
            return Ok (produto);
        }

        [HttpPut]
        [Route ("Atualizar")]
        // [ApiVersion ("1.0")]
        public IActionResult Atualizar ([FromBody] Produto produto)
        {
            var prod = _repositorio.Obter (produto.Id);
            if (prod == null) return NotFound ();

            if (produto.Codigo == "")
                return BadRequest ("Codigo do produto não informado");

            if (string.IsNullOrEmpty (produto.Descricao))
                return BadRequest ("Descrição do produto não informada");

            _repositorio.Editar (produto);
            return Ok ("Produto Atualizado com sucesso");
        }

        [HttpDelete("{id}")]
        //   [ApiVersion ("1.0")]
        [Route ("Apagar")]
        public IActionResult Apagar (int id)
        {
            var prod = _repositorio.Obter (id);
            if (prod == null) return NotFound ();
            _repositorio.Excluir (prod);
            return Ok ();
        }

        [HttpGet ("{codigo}")]
        [Route("ObterPorCodigo")]
        //   [ApiVersion ("1.0")]
        public IActionResult ObterPorcodigo (string codigo) => Ok ("Produto Atulizado com sucesso");

    }
}