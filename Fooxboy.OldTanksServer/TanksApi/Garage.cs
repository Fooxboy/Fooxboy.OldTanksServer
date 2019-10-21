using Fooxboy.OldTanksServer.Interfaces.TanksApi;
using Fooxboy.OldTanksServer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fooxboy.OldTanksServer.TanksApi
{
    public class Garage : IGarage
    {
        public Models.Garage GetGarageFromId(long userId)
        {
            throw new NotImplementedException();
        }

        public Models.Garage GetGarageFromNickname(string nickname)
        {
            throw new NotImplementedException();
        }

        public bool Register(long userId)
        {
            throw new NotImplementedException();
        }

        public bool SetGarage(Models.Garage garage)
        {
            throw new NotImplementedException();
        }
    }
}
