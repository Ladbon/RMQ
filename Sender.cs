using System;

namespace Sender
{
    class Program
    {
        static void Main(string[] args)
        {
            //Välkomna kära användaren
            Console.WriteLine("Hej och välkomna till Ladbons meddelande app.");

            //Variabler
            RMQ sender = new RMQ();
            string message;
            bool off = false;

            do
            {
                //Skriv meddelandet
                Console.WriteLine("\n" +
                    "skriv ditt meddelande nedan, avsluta med <enter>?");
                message = Console.ReadLine();

                //Publisha Meddelandet
                sender.Sender(message);

                Console.WriteLine("[x] Skickat {0}", message + "\n");
            } while (!off);

        }
    }
}
