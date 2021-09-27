using Microsoft.AspNetCore.Mvc;
using SistemaDeVendas.Interfaces;
using SistemaDeVendas.Models;

namespace SistemaDeVendas.Controllers
{
    [Route("api/estoques")]
    public class ProdutoController : ControllerBase
    {
        private readonly IProdutoRepository _produtoRepository;
        public ProdutoController(IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }

        [HttpGet]
        public IActionResult Buscar()
        {
            var todosOsProdutos = _produtoRepository.ListarTodosOsProdutos();

            if (todosOsProdutos == null) return BadRequest();

            return Ok(todosOsProdutos);
        }

        [HttpGet]
        public IActionResult BuscarPorId(int id)
        {
            if (id == 0) return BadRequest();

            var produto = _produtoRepository.PesquisarProdutoPorId(id);

            if (produto == null) return NotFound();

            return Ok(produto);
        }

        [HttpPost]
        public IActionResult Adicionar([FromBody] Produto produto)
        {
            if (produto == null) return BadRequest();

            _produtoRepository.AdicionarProduto(produto);

            return Ok();
        }

        [HttpPut]
        public IActionResult Atualizar([FromBody] Produto produto)
        {
            if (produto == null) return NotFound();

            _produtoRepository.AtualizarProduto(produto);

            return NoContent();
        }

        [HttpDelete]
        public IActionResult Excluir(int id)
        {
            if (id == 0) return BadRequest();

            _produtoRepository.ExcluirProduto(id);

            return NoContent();
        }
    }
}
