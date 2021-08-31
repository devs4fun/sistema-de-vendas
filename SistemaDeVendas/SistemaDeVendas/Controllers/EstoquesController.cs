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
        public IActionResult Get(string palavraDePesquisa)
        {
            var resultadoPesquisa = _estoqueRepository.PesquisarProduto(palavraDePesquisa);
            return Ok(resultadoPesquisa);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var todosOsProdutos = _estoqueRepository.ListarTodosOsProdutos();
            return Ok(todosOsProdutos);
        }

        [HttpGet]
        public IActionResult GetById(int id)
        {
            var produto = _estoqueRepository.PesquisarProdutoPorId(id);

            if (produto == null) NotFound();

            return Ok(produto);
        }

        [HttpPost]
        public IActionResult AdicionarProduto([FromBody] Produto produto, int quantidade)
        {
            var id = _estoqueRepository.AdicionarProduto(produto, quantidade);

            return CreatedAtAction(nameof(GetById), new { id = id }, produto);
        }
    }
}
