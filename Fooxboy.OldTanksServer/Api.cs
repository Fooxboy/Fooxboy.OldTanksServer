using Fooxboy.OldTanksServer.Interfaces.TanksApi;
using Fooxboy.OldTanksServer.TanksApi;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fooxboy.OldTanksServer
{
    public class Api
    {
        public Api(Server server, IAccount account = null, IGarage garage= null, IBannedIPs bannedIps = null, IChatApi chat = null, IServerApi serverApi = null)
        {
            Account = account?? new Account();
            Garage = garage?? new Garage();
            BannedIP = bannedIps ?? new BannedIPs();
            Chat = chat ?? new Chat(server.Lobbies, server.Logger, server.Api);
            Server = serverApi ?? new ServerApi(server);
        }
        public IAccount Account { get; }
        public IGarage Garage { get; }
        public IBannedIPs BannedIP { get; }
        public IChatApi Chat { get; }
        public IServerApi Server { get; }
    }
}
