using UtilKits.RabbitMQ;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Threading;
using System.Threading.Tasks;
using RabbitMQ.Core.Queue.Model;

namespace RabbitMQ.Hosts
{
    public class TemplateQueueHostService : IHostedService
    {
        private readonly IServiceProvider _serviceProvider;

        public TemplateQueueHostService(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            using (var scope = _serviceProvider.CreateScope())
            {
                var consumer = scope.ServiceProvider.GetRequiredService<ConsumerBase<MessageQueue>>();

                consumer.SubscribeQueue();
            }

            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            using (var scope = _serviceProvider.CreateScope())
            {
                var consumer = scope.ServiceProvider.GetRequiredService<ConsumerBase<MessageQueue>>();

                consumer.EndSubcribe();
            }

            return Task.CompletedTask;
        }
    }
}
