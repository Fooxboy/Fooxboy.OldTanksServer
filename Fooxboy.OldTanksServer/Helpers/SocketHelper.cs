using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;

namespace Fooxboy.OldTanksServer.Helpers
{
    public class SocketHelper
    {
        private readonly Socket _socket;
        public SocketHelper(Socket socket)
        {
            _socket = socket;
        }

        public void Send(string message)
        {
            var data = Encoding.Unicode.GetBytes(message);
            _socket.Send(data);
        }
    }
}
