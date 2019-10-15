using System;
using System.Collections.Generic;
using System.Text;

namespace Fooxboy.OldTanksServer.Core
{
    public class CreateBattle : IRequest
    {
        public string Trigger => "cb";

        public string Execute(List<string> message, Lobby lobby)
        {
            throw new NotImplementedException();
        }
    }
}
