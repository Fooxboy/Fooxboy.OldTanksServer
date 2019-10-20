using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;

namespace Fooxboy.OldTanksServer
{
    public class RequestProccessor
    {
        private readonly Socket _socket;
        private readonly Lobby _lobby;
        public RequestProccessor(Socket socket, Lobby lobby)
        {
            this._socket = socket;
            this._lobby = lobby;
        }
        public string Start(string message)
        {
            var array = message.Split(";");
            var requests = Server.RequestsCommands;
            var request = requests.SingleOrDefault(r => r.Trigger == array[0]);
            if (request is null) return "error;";
            return request.Execute(array.ToList(), _lobby);
        }
    }
}
