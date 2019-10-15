using System;
using System.Collections.Generic;
using System.Text;

namespace Fooxboy.OldTanksServer.Core
{
    public class BuyGarage : IRequest
    {
        public string Trigger => "buyg";

        public string Execute(List<string> message, Lobby lobby)
        {
            var type = message[1];
            var itemId = Int32.Parse(message[2]);
            var count = type=="n"? Int32.Parse(message[3]): 0;
        }
    }
}
