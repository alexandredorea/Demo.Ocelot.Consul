using Demo.Microservico.Produtos.Models;
using System;
using System.Collections.Generic;

namespace Demo.Microservico.Produtos.Servico
{
    internal class ProdutoServico : IProdutoServico
    {
        public List<Produto> ObterTodos()
        {
            return new List<Produto>
            {
                new Produto(){ Id = Guid.NewGuid(), Nome = "Produto 001", Preco = 10.10m },
                new Produto(){ Id = Guid.NewGuid(), Nome = "Produto 002", Preco = 20.21m },
                new Produto(){ Id = Guid.NewGuid(), Nome = "Produto 003", Preco = 30.32m },
                new Produto(){ Id = Guid.NewGuid(), Nome = "Produto 004", Preco = 40.43m },
            };
        }
    }
}