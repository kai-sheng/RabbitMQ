using System;

namespace RabbitMQ.Core.Queue.Model
{
    public class MessageQueue
    {
        public Guid Key { get; set; }
        public string Message { get; set; }
    }
}
