using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using measurement_server;

namespace measurement_client
{
    class Program
    {
        static async Task Main(string[] args)
        {
            ClientRuntime client = new ClientRuntime();

            await client.RunSequence(args[0], 9000, args[1]);
        }
    }
}
