using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using lib;

namespace measurement_server
{
    
    public class Server : UDPCommunicator
    {
        public Server(int port)
        {
            _socket = new UdpClient(new IPEndPoint(IPAddress.Any, port));
        }
    }
}
