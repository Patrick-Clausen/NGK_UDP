using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace measurement_server
{
    public struct UDPMessage
    {
        public string Message;
        public IPEndPoint Address;
    }

    public class Server
    {
        private UdpClient _socket;

        public Server(int port)
        {
            _socket = new UdpClient(new IPEndPoint(IPAddress.Any, 9000));
        }

        public void Send(UDPMessage message)
        {
            byte[] data = Encoding.UTF8.GetBytes(message.Message);
            _socket.Send(data, data.Length, message.Address);
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
