using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fooxboy.OldTanksServer
{
    public class RequestProccessor
    {
        public string Start(string message)
        {
            var array = message.Split(";");
            var requests = Server.RequestsCommands;
            var request = requests.SingleOrDefault(r => r.Trigger == array[0]);
            if (request is null) return "error;";
            return request.Execute(array.ToList());
        }
    }
}
