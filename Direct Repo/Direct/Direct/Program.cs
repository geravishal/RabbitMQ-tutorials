using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Direct
{
    class Program
    {
        /// <summary>
        /// When we donot want to listen all the messages but are interested in some of the messages matching routiung key,then we use direct exchange
        /// We can set only 1 criteria in direct type of exchange
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.ExchangeDeclare(exchange: "OnlineUsers", type: "direct");


                string message1 = "Send to facebook users";
                var body1 = Encoding.UTF8.GetBytes(message1);
                channel.BasicPublish(exchange: "OnlineUsers",
                                     routingKey: "facebook",
                                     basicProperties: null,
                                     body: body1);


                string message2 = "Send to twitter users";
                var body2 = Encoding.UTF8.GetBytes(message2);
                channel.BasicPublish(exchange: "OnlineUsers",
                                     routingKey: "twitter",
                                     basicProperties: null,
                                     body: body2);

                Console.WriteLine(" [x] Sent {0} {1}", message1, message2);
            }

            Console.WriteLine(" Press [enter] to exit.");
            Console.ReadLine();
        }
    }
}
