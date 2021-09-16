using Microsoft.AspNetCore.Mvc;
using SistemaDeVendas.Interfaces;
using SistemaDeVendas.Models;

namespace SistemaDeVendas.Controllers
{
    [Route("api/estoques")]
    public class EstoquesController : ControllerBase
    {
        private readonly IEstoqueRepository _estoqueRepository;
        public EstoquesController(IEstoqueRepository estoqueRepository)
        {
            _estoqueRepository = estoqueRepository;
        }

        [HttpGet]
        public IActionResult Buscar()
        {
            var todosOsProdutos = _estoqueRepository.ListarTodosOsProdutos();

            if (todosOsProdutos == null) return BadRequest();

            return Ok(todosOsProdutos);
        }

        [HttpGet]
        public IActionResult BuscarPorId(int id)
        {
            if (id == 0) return BadRequest();

            var produto = _estoqueRepository.PesquisarProdutoPorId(id);

            if (produto == null) return NotFound();

            return Ok(produto);
        }

        [HttpPost]
        public IActionResult Adicionar([FromBody] Produto produto)
        {
            if (produto == null) return BadRequest();

            _estoqueRepository.AdicionarProduto(produto);

            return Ok();
        }

        [HttpPut]
        public IActionResult Atualizar([FromBody] Produto produto)
        {
            if (produto == null) return NotFound();

            _estoqueRepository.AtualizarProduto(produto);

            return NoContent();
        }

        [HttpDelete]
        public IActionResult Excluir(int id)
        {
            if (id == 0) return BadRequest();

            _estoqueRepository.ExcluirProduto(id);

            return NoContent();
        }
    }
}
