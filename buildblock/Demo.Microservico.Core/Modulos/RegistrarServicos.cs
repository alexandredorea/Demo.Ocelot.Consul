using Consul;
using Demo.Microservico.Core.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Microsoft.Extensions.Configuration
{
    public static class RegistrarServicos
    {
        /// <summary>
        /// Responsável por configurar onde o Serviço vai se auto-registrar, ou seja, será
        /// registrado no Consul (Cliente Consul) o Serviço que se auto-registrou para o
        /// Gateway saber que rota tomar
        /// </summary>
        /// <param name="services">Serviço que deseja se registrar no Consul</param>
        /// <param name="configuracaoServico"></param>
        /// <returns>IServiceCollection com a Injeção de Dependência do Consul configurado</returns>
        public static IServiceCollection RegistrarServicoConsul(this IServiceCollection services, ConfiguracaoServico configuracaoServico)
        {
            if (configuracaoServico == null)
                throw new ArgumentNullException(nameof(configuracaoServico));
            
            services.AddSingleton<IConsulClient, ConsulClient>(p => new ConsulClient(consulConfig =>
            {
                consulConfig.Address = configuracaoServico.ServiceDiscoveryAddress;
            }));
            return services;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="app"></param>
        /// <returns></returns>
        public static IApplicationBuilder UsarConsul(this IApplicationBuilder app, IConfiguration configuration)
        {
            //if (configuration == null)
            //    throw new ArgumentNullException(nameof(configuration));

            //var consulClient = app.ApplicationServices.GetRequiredService<IConsulClient>();
            //var logger = app.ApplicationServices.GetRequiredService<ILoggerFactory>().CreateLogger("Agente de serviço Consul");
            //var lifetime = app.ApplicationServices.GetRequiredService<IApplicationLifetime>();

            //var registration = new AgentServiceRegistration
            //{
            //    ID = configuration.GetValue<string>("Consul:ServiceId"),
            //    Name = configuration.GetValue<string>("Consul:ServiceName"),
            //    Address = configuration.GetValue<string>("Consul:ServiceHost"),
            //    Port = configuration.GetValue<int>("Consul:ServicePort")
            //};

            //logger.LogInformation($"Descoberta do serviço: {registration.ID}. Registrando serviço {registration.Name} no Consul");
            //consulClient.Agent.ServiceDeregister(registration.ID).ConfigureAwait(true); //desregistrando caso ele já exista (se não existir não faz nada)
            //consulClient.Agent.ServiceRegister(registration).ConfigureAwait(true);      //registrando o serviço novamente (atualiza alguma nova informação)

            //lifetime.ApplicationStopping.Register(() =>
            //{
            //    logger.LogInformation($"Parando o registro: {registration.ID}. Desregistrando serviço {registration.Name} do Consul");
            //    consulClient.Agent.ServiceDeregister(registration.ID).ConfigureAwait(true);
            //});

            return app;
        }
    }
}