using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using lib;

namespace measurement_server
{
    public class ServerRuntime
    {
        private Server _server;
        private Dictionary<string, string> _commandFilesDictionary;

        public bool keepGoing = true;

        public ServerRuntime(int port, Dictionary<string, string> commandFilesDictionary)
        {
            _commandFilesDictionary = commandFilesDictionary;
            _server = new Server(port);
            runServer();
        }

        private async void runServer()
        {
            while (keepGoing)
            {
                UDPMessage commandMessage = await _server.Receive();
                string file;
                if (_commandFilesDictionary.TryGetValue(commandMessage.Message, out file))
                {
                    if (File.Exists(file))
                    {
                        string fileContents = System.IO.File.ReadAllText(@file);

                        _server.Send(
                            new UDPMessage()
                            {
                                Message = fileContents,
                                Address = commandMessage.Address
                            }
                            );
                    }

                }
            }
            
        }

    }
}
