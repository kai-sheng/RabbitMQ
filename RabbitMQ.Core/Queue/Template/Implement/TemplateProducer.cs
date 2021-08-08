using System.Collections.Generic;
using UtilKits.RabbitMQ;
using RabbitMQ.Client;
using RabbitMQ.Core.Queue.Model;

namespace RabbitMQ.Core.Queue.Template.Implement
{
    public class TemplateProducer : ProducerBase<MessageQueue>, ITemplateProducer
    {
        protected override string ExchangeName => QueueKeys.ExchangeName;
        protected override string RoutingKeyName => QueueKeys.RoutingKeyName;
        protected override string QueueName => QueueKeys.QueueName;


        protected override byte Priority { get; set; } = 1;

        //請自行修改參數
        protected override ConnectionFactory ConnectionFactory => new ConnectionFactory
        {
            HostName = "HostName",
            UserName = "UserName",
            Password = "Password",
            Port = 5672,
            VirtualHost = "VirtualHost",
            DispatchConsumersAsync = true
        };
    }
}
