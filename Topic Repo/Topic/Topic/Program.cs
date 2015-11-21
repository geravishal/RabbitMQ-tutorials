using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Topic
{
    class Program
    {
        /// <summary>
        /// When we need to disseminate messages to all queues bind to that exchange filter on the basis of more than one criteria. 
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.ExchangeDeclare(exchange: "OnlineUsers", type: "topic");


                string message1 = "Send to facebook men young users";
                var body1 = Encoding.UTF8.GetBytes(message1);
                channel.BasicPublish(exchange: "OnlineUsers",
                                     routingKey: "facebook.men.young",
                                     basicProperties: null,
                                     body: body1);

                string message2 = "Send to facebook women young users";
                var body2 = Encoding.UTF8.GetBytes(message2);
                channel.BasicPublish(exchange: "OnlineUsers",
                                     routingKey: "facebook.women.young",
                                     basicProperties: null,
                                     body: body2);


                string message3 = "Send to twitter men old users";
                var body3 = Encoding.UTF8.GetBytes(message3);
                channel.BasicPublish(exchange: "OnlineUsers",
                                     routingKey: "twitter.men.old",
                                     basicProperties: null,
                                     body: body3);

                string message4 = "Send to twitter women old users";
                var body4 = Encoding.UTF8.GetBytes(message4);
                channel.BasicPublish(exchange: "OnlineUsers",
                                     routingKey: "twitter.women.old",
                                     basicProperties: null,
                                     body: body4);

                Console.WriteLine("{0} {1} {2} {3}", message1 + "\n", message2 + "\n", message3 + "\n", message4);
            }

            Console.WriteLine(" Press [enter] to exit.");
            Console.ReadLine();
        }
    }
}
