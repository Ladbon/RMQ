using System;
using RabbitMQ.Client;

namespace Sender
{
    class RMQ
    {
        //Skicka meddelanden
        public void Sender(string message)
        {
            factory = new ConnectionFactory() { HostName = "localhost" };

            using (connection = factory.CreateConnection())
            using (model = connection.CreateModel())
            {
                model.ExchangeDeclare("Messages", ExchangeType.Fanout);

                properties = model.CreateBasicProperties();
                properties.Persistent = true;

                var body = Encoding.UTF8.GetBytes(message);

                model.BasicPublish(exchange: "Messages",
                         routingKey: "",
                         basicProperties: properties,
                         body: body);
            }
        }
        //Stäng anslutningen
        public void Close_Connection()
        {
            model.Close();
            connection.Close();
        }

        //Variabler
        private ConnectionFactory factory;
        private IConnection connection;
        private IModel model;
        private IBasicProperties properties;
    }
}
