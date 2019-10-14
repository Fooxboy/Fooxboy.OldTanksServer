using System;
using System.Collections.Generic;
using System.Text;

namespace Fooxboy.OldTanksServer.Core
{
    public class JoinToBattle : IRequest
    {
        public string Trigger => "enb";

        public string Execute(List<string> message)
        {
            var battleId = Int64.Parse(message[1]);
            var command = Int32.Parse(message[2]);
            throw new NotImplementedException();
        }
    }
}
