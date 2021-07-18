using Demo.Microservico.Produtos.Models;
using System.Collections.Generic;

namespace Demo.Microservico.Produtos.Servico
{
    public interface IProdutoServico
    {
        List<Produto> ObterTodos();
    }
}