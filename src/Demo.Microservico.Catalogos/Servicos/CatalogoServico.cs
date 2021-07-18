using Demo.Microservico.Catalogos.Models;
using System;
using System.Collections.Generic;

namespace Demo.Microservico.Catalogos.Servicos
{
    internal class CatalogoServico : ICatalogoServico
    {
        public List<Categoria> ObterTodas()
        {
            return new List<Categoria>
            {
                new Categoria(){ Id = Guid.NewGuid(), Nome = "Categoria 001" },
                new Categoria(){ Id = Guid.NewGuid(), Nome = "Categoria 002" },
                new Categoria(){ Id = Guid.NewGuid(), Nome = "Categoria 003" },
                new Categoria(){ Id = Guid.NewGuid(), Nome = "Categoria 004" },
            };
        }
    }
}