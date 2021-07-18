using System;

namespace Demo.Microservico.Produtos.Models
{
    public class Produto
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public decimal Preco { get; set; }
    }
}