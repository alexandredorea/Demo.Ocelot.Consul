using Demo.Microservico.Produtos.Models;
using Demo.Microservico.Produtos.Servico;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Diagnostics;

namespace Demo.Microservico.Produtos.Controllers
{
    [ApiController]
    [Route("api/produto")]
    public class ProdutoController : ControllerBase
    {
        private readonly IProdutoServico produtoServico;

        public ProdutoController(IProdutoServico produtoServico)
        {
            this.produtoServico = produtoServico;
        }

        [HttpGet("obtertodos")]
        public IActionResult ObterTodos()
        {
            try
            {
                return Ok(produtoServico.ObterTodos());
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPost("criar")]
        public IActionResult Criar([FromBody] Produto produto)
        {
            try
            {
                Debug.WriteLine($"POST: Informação de {nameof(Produto)}");
                Debug.WriteLine($"Id: {produto.Id}");
                Debug.WriteLine($"Nome: {produto.Nome}");
                Debug.WriteLine($"Preco: {produto.Preco}");
                return Ok(produto);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPut("atualizar")]
        public IActionResult Atualizar([FromBody] Produto produto)
        {
            try
            {
                Debug.WriteLine($"PUT: Informação de {nameof(Produto)}");
                Debug.WriteLine($"Id: {produto.Id}");
                Debug.WriteLine($"Nome: {produto.Nome}");
                Debug.WriteLine($"Preco: {produto.Preco}");
                return Ok(produto);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpDelete("remover/{id}")]
        public IActionResult Remover(Guid id)
        {
            try
            {
                Debug.WriteLine($"DELETE: {nameof(Produto)} Id: {id}");
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}