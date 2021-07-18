using Demo.Microservico.Core.Models;
using Microsoft.Extensions.Configuration;
using System;

namespace Demo.Microservico.Core.Modulos
{
    public static class ConfiguracaoServicoExtension
    {
        public static ConfiguracaoServico GetServiceConfig(this IConfiguration configuration)
        {
            if (configuration == null)
            {
                throw new ArgumentNullException(nameof(configuration));
            }

            var serviceConfig = new ConfiguracaoServico
            {
                ServiceDiscoveryAddress = configuration.GetValue<Uri>("ServiceConfig:serviceDiscoveryAddress"),
                NomeServico = configuration.GetValue<string>("ServiceConfig:serviceName"),
                ServiceHost = configuration.GetValue<string>("ServiceConfig:serviceAddress"),
                ServicoId = configuration.GetValue<string>("ServiceConfig:serviceId")
            };

      //      -ServiceConfig__serviceDiscoveryAddress = http://consul:8500
      //-ServiceConfig__serviceAddress = http://catalogos:9020
      //-ServiceConfig__serviceName = Demo.Microservico.Catalogos
      //- ServiceConfig__serviceId = Catalogos
            return serviceConfig;
        }
    }
}