using ProjetoDeliverIT.IntegrationsInterfaces;
using ProjetoDeliverIT.Models;
using RabbitMQ.Client;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ProjetoDeliverIT.Integrations
{
    public class RabbitMqPublisher : IRabbitMqPublisher
    {
        private const string QueueName = "bill_created";

        public async Task PublishCreatedAsync(object obj)
        {
            var factory = new ConnectionFactory
            {
                HostName = "localhost",
                Port = 5672,
                UserName = "guest",
                Password = "guest"
            };

            await using var connection = await factory.CreateConnectionAsync();
            await using var channel = await connection.CreateChannelAsync();

            await channel.QueueDeclareAsync(
                queue: QueueName,
                durable: true,
                exclusive: false,
                autoDelete: false
            );

            var message = JsonSerializer.Serialize(obj);
            var body = Encoding.UTF8.GetBytes(message);

            await channel.BasicPublishAsync(
                exchange: "",
                routingKey: QueueName,
                body: body
            );
        }
    }
}
