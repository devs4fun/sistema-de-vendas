﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemaDeVendas.Models;
using SistemaDeVendas.Repository;
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

        public VendasController(IVendasRepository vendasRepository)
        {
            _vendasRepository = vendasRepository;
        }

        [HttpPatch("{id}")]
        public ActionResult Patch(int id)
        {
            if (id <= 0)
                return StatusCode(400);

            var venda =_vendasRepository.Patch(id);

            if (venda == false)
                return StatusCode(500);

            return StatusCode(201, venda);
        }

        [HttpGet]
        public ActionResult Get(int id)
        {
            if (id <= 0 )
                return BadRequest();

            var produto = _vendasRepository.GetById(id);

            return Ok(produto);
        }
        [HttpGet]
        public ActionResult GetAll()
        {
            var produtos = _vendasRepository.GetAll();
            if (produtos == null || produtos.Any() == false)
                return NotFound();

            return Ok(produtos);
        }

        [HttpPut]
        public IActionResult Put([FromBody]Venda venda, [FromHeader]VendasRequestUpdate vendarequest)
        {
            var vendaDoBanco = _vendasRepository.GetById(venda.Id);
            vendaDoBanco.Update(vendarequest);
            _vendasRepository.Update(venda, vendarequest);

            return Ok();
        }

        [HttpDelete]
        public IActionResult Delete(Venda venda)
        {
            _vendasRepository.Delete(venda);
            return Ok();
        }

    }
}
