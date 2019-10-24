using Fooxboy.OldTanksServer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fooxboy.OldTanksServer.Interfaces.TanksApi
{
    public interface IBannedIPs
    {
        bool CheckBan(string ip);
        bool Ban(string ip, string reason, string nickname = "Неавторизован.");

        BannedIp GetBan(string ip);
        List<BannedIp> GetListBans(int count = 0);

    }
}
