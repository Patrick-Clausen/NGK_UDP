using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using lib;

namespace measurement_client
{ 
    public class Client : UDPCommunicator
    {
        public Client(string address, int port)
        {
            _socket = new UdpClient();
            _socket.Connect(new IPEndPoint(IPAddress.Parse(address), port));
        }

        public void Send(string message)
        {
            byte[] data = Encoding.UTF8.GetBytes(message);
            _socket.Send(data, data.Length);
        }
    }
}
