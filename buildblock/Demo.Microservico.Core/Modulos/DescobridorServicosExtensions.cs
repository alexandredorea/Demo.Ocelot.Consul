using Consul;
using Demo.Microservico.Core.Models;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

namespace Demo.Microservico.Core.Modulos
{
    public class DescobridorServicosExtensions : IHostedService
    {
        private readonly IConsulClient cliente;
        private readonly ConfiguracaoServico servico;
        private readonly ILogger<DescobridorServicosExtensions> logger;

        public DescobridorServicosExtensions(
            ILogger<DescobridorServicosExtensions> logger,
            IConsulClient cliente,
            ConfiguracaoServico servico)
        {
            this.logger = logger;
            this.cliente = cliente;
            this.servico = servico;
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            logger.LogInformation($"Descoberta do serviço: {servico.ServicoId}. Registrando serviço {servico.NomeServico} no Consul");

            var registro = new AgentServiceRegistration
            {
                ID = servico.ServicoId,
                Name = servico.NomeServico,
                Address = servico.ServiceHost,
                Port = servico.ServicePort
            };

            //desregistrando caso ele já exista (se não existir não faz nada)
            await cliente.Agent
                .ServiceDeregister(registro.ID, cancellationToken)
                .ConfigureAwait(true);
            //registrando o serviço novamente (atualiza alguma nova informação)
            await cliente.Agent
                .ServiceRegister(registro, cancellationToken)
                .ConfigureAwait(true);
        }

        public async Task StopAsync(CancellationToken cancellationToken)
        {
            logger.LogInformation($"Parando o registro: {servico.ServicoId}. Desregistrando serviço {servico.NomeServico} do Consul");
            await cliente.Agent.ServiceDeregister(servico.ServicoId, cancellationToken).ConfigureAwait(true);
        }
    }
}