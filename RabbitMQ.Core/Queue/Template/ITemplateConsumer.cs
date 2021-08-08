using UtilKits.RabbitMQ;
using System.Threading.Tasks;
using RabbitMQ.Core.Queue.Model;

namespace RabbitMQ.Core.Queue.Template
{
    public interface ITemplateConsumer : IConsumerBase<MessageQueue>
    {
        /// <summary>
        /// 主動讀取 QUEUE，取資料時執行工作
        /// </summary>
        new Task PullQueue();
    }
}
