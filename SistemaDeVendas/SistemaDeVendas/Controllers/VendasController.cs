using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemaDeVendas.Models;
using SistemaDeVendas.Repository;
using SistemaDeVendas.Serviço;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaDeVendas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VendasController : ControllerBase
    {
        private readonly IVendasRepository _vendasRepository;
        private readonly IServicoDeVenda _servicoDeVenda;

        public VendasController(IVendasRepository vendasRepository,
            IServicoDeVenda servicoDeVenda)
        {
            _vendasRepository = vendasRepository;
            _servicoDeVenda = servicoDeVenda;
        }

        [HttpPost]
        public ActionResult Post([FromBody]VendaRequest vendaRequest)
        {
            var vendaRealizada = _servicoDeVenda.Vender(vendaRequest);

            if (vendaRealizada == false)
                return BadRequest();

            return Ok(vendaRealizada);
        }

        //[HttpGet]
        //public ActionResult Get(int id)
        //{
        //    if (id <= 0 )
        //        return BadRequest();

        //    var produto = _vendasRepository.GetById(id);

        //    return Ok(produto);
        //}
        //[HttpGet]
        //public ActionResult GetAll()
        //{
        //    var produtos = _vendasRepository.GetAll();
        //    if (produtos == null || produtos.Any() == false)
        //        return NotFound();

        //    return Ok(produtos);
        //}

        //[HttpPut]
        //public IActionResult Put([FromBody]Venda venda, [FromHeader]VendaRequest vendarequest)
        //{
        //    var vendaDoBanco = _vendasRepository.GetById(venda.Id);
        //   // vendaDoBanco.Update(vendarequest);
        //    _vendasRepository.Update(venda, vendarequest);

        //    return Ok();
        //}

        //[HttpDelete]
        //public IActionResult Delete(Venda venda)
        //{
        //    _vendasRepository.Delete(venda);
        //    return Ok();
        //}

    }
}
