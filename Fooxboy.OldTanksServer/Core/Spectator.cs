using System;
using System.Collections.Generic;
using System.Text;

namespace Fooxboy.OldTanksServer.Core
{
    public class Spectator : IRequest
    {
        public string Trigger => "spec";

        public string Execute(List<string> message, Lobby lobby)
        {

           // throw new NotImplementedException();
        }
    }
}
