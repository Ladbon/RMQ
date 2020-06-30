using System;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace Subscriber

{
    class Program
    {
        static void Main(string[] args)
        {
            //Variabler
            Listener subscriber = new Listener();
            Server server = new Server();

            //Välkomna kära användaren
            Console.WriteLine("Hej och välkomna till Ladbons meddelande app.");

            //Anslutning till SQL Servern
            server.Init_SQL_Connection();

            //Anslutning till RabbitMQ
            subscriber.Listen();

            //Spara datat
            server.Save_Data(subscriber.Get_Current_Message());

            //Visa upp data
            server.Load_Table_Form();

            //Stäng av allting
            subscriber.Close_Connection();
            
            Console.WriteLine("stänger nu");

            Console.ReadLine();
        }
    }
}
