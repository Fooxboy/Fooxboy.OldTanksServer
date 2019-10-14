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
        public Lobby(User currentUser, Socket socket)
        {
            this._user = currentUser;
            this._socket = socket;
        }
    }
}
