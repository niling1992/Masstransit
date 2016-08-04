using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RabbitMQ.Client;

namespace RabbitMQ.HelloWorder.Producer
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Press 'Enter' to send a message.To exit, Ctrl + C");

            var factory = new ConnectionFactory() { HostName = "localhost" };
            using (var connection = factory.CreateConnection())
            {
                while (Console.ReadLine() != null)
                {
                    using (var channel = connection.CreateModel())
                    {
                        //创建一个名叫"hello"的消息队列
                        channel.QueueDeclare(queue: "hello",
                            durable: false,
                            exclusive: false,
                            autoDelete: false,
                            arguments: null);

                        var message = "Hello World!";
                        var body = Encoding.UTF8.GetBytes(message);

                        //向该消息队列发送消息message
                        channel.BasicPublish(exchange: "",
                            routingKey: "hello",
                            basicProperties: null,
                            body: body);
                        Console.WriteLine(" [x] Sent {0}", message);
                    }
                }
            }

            Console.WriteLine(" Press [Ctrl + C] to exit.");
            Console.ReadLine();
        }

    }
}
