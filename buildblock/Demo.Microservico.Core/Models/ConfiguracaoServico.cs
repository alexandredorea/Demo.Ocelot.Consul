using System;

namespace Demo.Microservico.Core.Models
{
    /// <summary>
    /// Classe tem a responsabilidade de ser mapeada usando Strong Type,
    /// onde as propriedades vem do arquivo de configurações docker-compose.override.yml
    /// </summary>
    public class ConfiguracaoServico
    {
        public Uri ServiceDiscoveryAddress { get; set; }
        public string ServicoId { get; set; }
        public string NomeServico { get; set; }
        public string ServiceHost { get; set; }
        public int ServicePort { get; set; }
    }
}