using Fooxboy.OldTanksServer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fooxboy.OldTanksServer.Interfaces.TanksApi
{
    public interface IBannedIPs
    {
        public bool CheckBan(string ip);
        public bool Ban(string ip, string reason, string nickname = "Неавторизован.");

        public BannedIp GetBan(string ip);
        public List<BannedIp> GetListBans(int count = 0);

    }
}
