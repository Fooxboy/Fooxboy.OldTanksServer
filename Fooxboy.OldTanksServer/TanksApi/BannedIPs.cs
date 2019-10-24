using Fooxboy.OldTanksServer.Interfaces.TanksApi;
using Fooxboy.OldTanksServer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fooxboy.OldTanksServer.TanksApi
{
    public class BannedIPs : IBannedIPs
    {
        public bool Ban(string ip, string reason, string nickname = "Неавторизован.")
        {
            throw new NotImplementedException();
        }

        public bool CheckBan(string ip)
        {
            throw new NotImplementedException();
        }

        public BannedIp GetBan(string ip)
        {
            throw new NotImplementedException();
        }

        public List<BannedIp> GetListBans(int count = 0)
        {
            throw new NotImplementedException();
        }
    }
}
