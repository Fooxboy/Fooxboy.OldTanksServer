using Fooxboy.OldTanksServer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fooxboy.OldTanksServer.Interfaces.TanksApi
{
    public interface IGarage
    {
        bool Register(long userId);
        Garage GetGarageFromId(long userId);
        Garage GetGarageFromNickname(string nickname);
        bool SetGarage(Garage garage);
    }
}
