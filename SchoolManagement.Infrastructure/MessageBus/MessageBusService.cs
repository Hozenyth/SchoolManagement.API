using Microsoft.Extensions.Configuration;
using RabbitMQ.Client;
using SchoolManagement.Core.Services;

namespace SchoolManagement.Infrastructure.MessageBus
{
    public class MessageBusService : IMessageBusService
    {
        private readonly ConnectionFactory _factory;
        public MessageBusService(IConfiguration configuration)
        {
            _factory = new ConnectionFactory
            {
                HostName = "localhost",
            };
        }
        public void Publish(string queue, byte[] message)
        {
            using (var connection = _factory.CreateConnection())
            {
                using (var channel = connection.CreateModel())
                {
                    
                    channel.QueueDeclare(
                        queue: queue,
                        durable: false,
                        exclusive: false,
                        autoDelete: false,
                        arguments: null);

                    channel.BasicPublish(
                        exchange:"",
                        routingKey: queue,
                        basicProperties: null,
                        body: message);
                        
                }
            }
        }
    }
}
