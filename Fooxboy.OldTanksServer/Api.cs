using Fooxboy.OldTanksServer.TanksApi;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fooxboy.OldTanksServer
{
    public class Api
    {
        public Api()
        {
            Account = new Account();
        }
        public Account Account { get; }
    }
}
