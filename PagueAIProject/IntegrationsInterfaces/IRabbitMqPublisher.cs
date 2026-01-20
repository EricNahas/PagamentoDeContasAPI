using ProjetoDeliverIT.Models;

namespace ProjetoDeliverIT.IntegrationsInterfaces
{
    public interface IRabbitMqPublisher
    {
        Task PublishCreatedAsync(object obj);
    }
}
