using System;
using System.Collections.Generic;
using System.Text;

namespace Fooxboy.OldTanksServer.Core
{
    public class GetPlayers : IRequest
    {
        public string Trigger => "getp";

        public string Execute(List<string> message, Lobby lobby)
        {
            throw new NotImplementedException();
        }
    }
}
