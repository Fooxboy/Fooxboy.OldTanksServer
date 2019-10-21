using Fooxboy.OldTanksServer.Interfaces.TanksApi;
using Fooxboy.OldTanksServer.TanksApi;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fooxboy.OldTanksServer
{
    public class Api
    {
        public Api(IAccount account, IGarage garage)
        {
            Account = account?? new Account();
            Garage = garage?? new Garage();
        }
        public IAccount Account { get; }
        public IGarage Garage { get; }
    }
}
