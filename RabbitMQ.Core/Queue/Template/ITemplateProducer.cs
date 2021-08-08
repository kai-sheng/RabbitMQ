using UtilKits.RabbitMQ;
using System;
using System.Collections.Generic;
using System.Text;
using RabbitMQ.Core.Queue.Model;

namespace RabbitMQ.Core.Queue.Template
{
    public interface ITemplateProducer : IProducerBase<MessageQueue>
    {
        /// <summary>
        /// 上傳 QUEUE 
        /// </summary>
        /// <param name="Source">QUEUE 字串</param>
        new void Publish(MessageQueue Source);
    }
}
