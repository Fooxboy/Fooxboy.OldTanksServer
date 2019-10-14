using Fooxboy.OldTanksServer.Models;
using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;

namespace Fooxboy.OldTanksServer
{
    public class Lobby
    {
        private readonly User _user;
        private readonly Socket _socket;
        private readonly RequestProccessor _proccessor;
        public Lobby(User currentUser, Socket socket)
        {
            this._user = currentUser;
            this._socket = socket;
            this._proccessor = new RequestProccessor();
        }

        public void LoadLobby()
        {

        }

        public void ListerNewRequest()
        {
            while(true)
            {
                if (_socket.Available == 0) return;
                var builder = new StringBuilder();
                int bytes = 0;
                byte[] data = new byte[256];
                do
                {
                    bytes = _socket.Receive(data);
                    builder.Append(Encoding.Unicode.GetString(data, 0, bytes));
                }
                while (_socket.Available > 0);
                var message = builder.ToString();
                _proccessor.Start(message);
            }
            
        }
    }
}
