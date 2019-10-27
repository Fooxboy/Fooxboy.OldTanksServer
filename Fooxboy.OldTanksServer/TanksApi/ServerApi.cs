using Fooxboy.OldTanksServer.Interfaces.TanksApi;
using Fooxboy.OldTanksServer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fooxboy.OldTanksServer.TanksApi
{
    public class ServerApi : IServerApi
    {
        private readonly Server _server;
        public ServerApi(Server server)
        {
            _server = server;
        }
        public List<User> GetOnlineUsers()
        {
            throw new NotImplementedException();
        }
    }
}
