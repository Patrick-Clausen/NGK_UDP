using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace lib
{
    public abstract class UDPCommunicator
    {
        protected UdpClient _socket;

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
