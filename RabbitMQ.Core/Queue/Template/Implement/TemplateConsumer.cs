using UtilKits.RabbitMQ;
using RabbitMQ.Client;
using System;
using System.Threading.Tasks;
using RabbitMQ.Core.Queue.Model;

namespace RabbitMQ.Core.Queue.Template.Implement
{
    public class TemplateConsumer : ConsumerBase<MessageQueue>, ITemplateConsumer
    {
        protected override string ExchangeName => QueueKeys.ExchangeName;
        protected override string RoutingKeyName => QueueKeys.RoutingKeyName;
        protected override string QueueName => QueueKeys.QueueName;

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



        protected override async Task Invoke(MessageQueue message)
        {
            await Task.Run(() =>
            {
                Console.WriteLine("Key：" + message.Key + "      " + "Message：" + message.Message);
            });
        }

        protected override async Task ExceptionHandler(Exception ex, string message)
        {
            await Task.Run(() =>
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(message);
            });
        }
    }
}
