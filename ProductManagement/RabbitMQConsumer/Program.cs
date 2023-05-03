using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;
using Newtonsoft.Json;

var factory = new ConnectionFactory();
factory.Uri = new Uri("amqp://guest:guest@localhost:5672");
var connection = factory.CreateConnection();
var channel = connection.CreateModel();

var consumer = new EventingBasicConsumer(channel);
consumer.Received += (sender, arguments) =>
{
    var message = Encoding.UTF8.GetString(arguments.Body.ToArray());
    Console.WriteLine($" [{arguments.RoutingKey}] Received {message}");
};
channel.BasicConsume(queue: "createdProducts", autoAck: true, consumer: consumer);
channel.BasicConsume(queue: "updatedProducts", autoAck: true, consumer: consumer);
channel.BasicConsume(queue: "deletedProducts", autoAck: true, consumer: consumer);

Console.ReadLine();