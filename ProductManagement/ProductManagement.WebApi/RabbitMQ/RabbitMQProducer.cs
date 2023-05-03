using Newtonsoft.Json;
using ProductManagement.BLL.DTOs;
using RabbitMQ.Client;
using System.Text;
using System.Threading.Channels;

namespace ProductManagement.WebApi.RabbitMQ
{
    public class RabbitMQProducer : IRabbitMQProducer
    {
        private readonly IConnection _connection;
        private readonly IModel _channel;
        public RabbitMQProducer()
        {
            var factory = new ConnectionFactory();
            factory.Uri = new Uri("amqp://guest:guest@localhost:5672");
            _connection = factory.CreateConnection();
            _channel = _connection.CreateModel();
            _channel.ExchangeDeclare("webApiExchange", ExchangeType.Direct, true);

            _channel.QueueDeclare("createdProducts", true, false, false, null);
            _channel.QueueBind("createdProducts", "webApiExchange", "product.created", null);

            _channel.QueueDeclare("updatedProducts", true, false, false, null);
            _channel.QueueBind("updatedProducts", "webApiExchange", "product.updated", null);

            _channel.QueueDeclare("deletedProducts", true, false, false, null);
            _channel.QueueBind("deletedProducts", "webApiExchange", "product.deleted", null);
        }
        public void SendProductCreatedMessage(ProductDTO createdProduct)
        {
            var serializedObject = JsonConvert.SerializeObject(createdProduct);
            var bytes = Encoding.UTF8.GetBytes(serializedObject);
            _channel.BasicPublish("webApiExchange", "product.created", null, bytes);
            Dispose();
        }

        public void SendProductDeletedMessage(ProductDTO deletedProduct)
        {
            var serializedObject = JsonConvert.SerializeObject(deletedProduct);
            var bytes = Encoding.UTF8.GetBytes(serializedObject);
            _channel.BasicPublish("webApiExchange", "product.deleted", null, bytes);
            Dispose();
        }

        public void SendProductUpdatedMessage(ProductDTO updatedProduct)
        {
            var serializedObject = JsonConvert.SerializeObject(updatedProduct);
            var bytes = Encoding.UTF8.GetBytes(serializedObject);
            _channel.BasicPublish("webApiExchange", "product.updated", null, bytes);
            Dispose();
        }

        void Dispose()
        {
            _channel.Close();
            _connection.Close();
        }
    }
}
