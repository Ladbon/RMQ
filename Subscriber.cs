using System;
using System.Collections.Generic;
using System.Text;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace Subscriber
{
    class Listener
    {

        public bool Listen()
        {
            factory = new ConnectionFactory() { HostName = "localhost" };
            found_message_push = false;
            using (connection = factory.CreateConnection())
            using (model = connection.CreateModel())
            {
                model.BasicQos(0, 1, true);

                model.ExchangeDeclare("Messages", ExchangeType.Fanout);

                queueName = model.QueueDeclare().QueueName;
                model.QueueBind(queue: queueName,
                                exchange: "Messages",
                                routingKey: "");

                consumer = new EventingBasicConsumer(model);


                Console.WriteLine("Letar efter meddelanden");

                consumer.Received += (model, ea) =>
                {
                    var body = ea.Body;
                    current_message = Encoding.UTF8.GetString(body);
                    found_message_push = true;

                    //Meddela end user
                    Console.WriteLine("NYTT MEDDELANDE!" +
                        "\n" +
                        "[x] {0}", current_message, "\n");
                };

                model.BasicConsume(queue: queueName,
                    autoAck: true,
                    consumer: consumer);

                found_message_push = false;

                Console.ReadKey();

                return found_message_push;
            }
        }

        public string Get_Current_Message()
        {
            if(current_message != null)
            { 
                return current_message;
            }
            else
            {
                return null;
            }
        }

        public void Close_Connection()
        {
            using (connection)
            using (model)
            {
                model.Close();
                connection.Close();
            }
        }

        public void Close_Consumer()
        {
            model.BasicCancel(consumer.ConsumerTag);
        }

        //Variabler
        private ConnectionFactory factory;
        private IConnection connection;
        private IModel model;
        private EventingBasicConsumer consumer;
        private string current_message;
        private string queueName;
        private bool found_message_push;
    }
}
