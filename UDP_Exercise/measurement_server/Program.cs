using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace measurement_server
{
    class Program
    {
        static async Task Main(string[] args)
        {
            

            Task serverTask = Task.Factory.StartNew(async () =>
            {
                var server = new Server(9000);

                while (true)
                {
                    var received = await server.Receive();
                    server.Send(new UDPMessage()
                    {
                        Address = received.Address,
                        Message = "returning " + received.Message
                    });
                    if (received.Message.Contains("quit"))
                    {
                        break;
                    }
                }
            });

            

            var client = new Client("127.0.0.1", 9000);

            while (true)
            {
                Console.Write("Input message: ");
                string message = Console.ReadLine();

                client.Send(message);

                UDPMessage returnMessage = await client.Receive();
                Console.WriteLine("Received reply: \"{0}\", from address: {1}", returnMessage.Message, returnMessage.Address.Address.ToString());
                if (message.Contains("quit"))
                {
                    break;
                }
            }

            await serverTask;
        }
    }
}
