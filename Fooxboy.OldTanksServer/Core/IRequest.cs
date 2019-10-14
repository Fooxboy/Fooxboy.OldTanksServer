using System;
using System.Collections.Generic;
using System.Text;

namespace Fooxboy.OldTanksServer.Core
{
    public interface IRequest
    {
        string Trigger { get; }
        public string Execute(List<string> message);
    }
}
