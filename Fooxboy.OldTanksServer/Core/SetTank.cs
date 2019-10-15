using System;
using System.Collections.Generic;
using System.Text;

namespace Fooxboy.OldTanksServer.Core
{
    public class SetTank : IRequest
    {
        public string Trigger => "setg";

        public string Execute(List<string> message, Lobby lobby)
        {
            var type = message[1];
            int currentColormap = Int32.Parse(message[2]);
            throw new NotImplementedException();
        }
    }
}
