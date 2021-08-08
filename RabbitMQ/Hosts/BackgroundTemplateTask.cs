using Microsoft.Extensions.Hosting;
using RabbitMQ.Core.Queue.Model;
using RabbitMQ.Core.Queue.Template;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace RabbitMQ.Hosts
{
    public class BackgroundTemplateTask : BackgroundService
    {
        private readonly ITemplateProducer _templateProducer;
        public BackgroundTemplateTask(ITemplateProducer templateProducer)
        {
            this._templateProducer = templateProducer;
        }
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            int current = 1;
            while (!stoppingToken.IsCancellationRequested)
            {
                var message = new MessageQueue
                {
                    Key = Guid.NewGuid(),
                    Message = $"第{current}筆：Queue訊息測試！！"
                };
                _templateProducer.Publish(message);

                current++;
                Thread.Sleep(1000);
            }

            await Task.CompletedTask;
        }
    }
}
