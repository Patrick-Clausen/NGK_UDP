using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace measurement_server
{ 
    public class Client
    {
        private UdpClient _socket;

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

        public async Task<UDPMessage> Receive()
        {
            var result = await _socket.ReceiveAsync();
            return new UDPMessage()
            {
                Message = Encoding.UTF8.GetString(result.Buffer, 0, result.Buffer.Length),
                Address = result.RemoteEndPoint
            };
        }
    }
}
