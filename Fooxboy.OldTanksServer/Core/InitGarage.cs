using System;
using System.Collections.Generic;
using System.Text;

namespace Fooxboy.OldTanksServer.Core
{
    public class InitGarage : IRequest
    {
        public string Trigger => "initg";

        public string Execute(List<string> message, Lobby lobby)
        {
            throw new NotImplementedException();
        }
    }
}
