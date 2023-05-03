using ProductManagement.BLL.DTOs;

namespace ProductManagement.WebApi.RabbitMQ
{
    public interface IRabbitMQProducer
    {
        void SendProductCreatedMessage(ProductDTO createdProduct);
        void SendProductUpdatedMessage(ProductDTO updatedProduct);
        void SendProductDeletedMessage(ProductDTO deletedProduct);
    }
}
