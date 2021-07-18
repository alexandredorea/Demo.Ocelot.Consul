using Demo.Microservico.Catalogos.Models;
using System.Collections.Generic;

namespace Demo.Microservico.Catalogos.Servicos
{
    public interface ICatalogoServico
    {
        List<Categoria> ObterTodas();
    }
}