using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fanout
{
    class Program
    {
        /// <summary>
        /// This is working fine for 1 to many relationship.When there is a need to disseminate the messages to all the interested queues
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.ExchangeDeclare(exchange: "logs", type: "fanout");


                string message1 = "Send to everyone2";

                var body = Encoding.UTF8.GetBytes(message1);

                channel.BasicPublish(exchange: "logs",
                                     routingKey: "",
                                     basicProperties: null,
                                     body: body);

                Console.WriteLine(" [x] Sent {0}", message1);
            }

            Console.WriteLine(" Press [enter] to exit.");
            Console.ReadLine();
        }
    }
}

