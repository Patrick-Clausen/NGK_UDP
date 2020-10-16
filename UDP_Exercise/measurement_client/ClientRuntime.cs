using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using lib;
using measurement_client;

namespace measurement_server
{
    public class ClientRuntime
    {
        public ClientRuntime()
        {
        }

        public async Task RunSequence(string hostip, int hostport, string command)
        {
            string controlledCommand = command.ToUpper();
            if (controlledCommand == "L" || controlledCommand == "U")
            {
                Client client = new Client(hostip, hostport);
                client.Send(controlledCommand);
                UDPMessage returnedMessage = await client.Receive();

                Console.WriteLine(returnedMessage.Message); 
            }
            else
            {
                Console.WriteLine("Please input a valid command [U/u, L/l]");
            }
        }
    }
}
