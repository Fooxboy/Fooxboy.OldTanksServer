using System;
using System.Collections.Generic;
using System.Text;

namespace Fooxboy.OldTanksServer.Interfaces
{
    public interface ITurret
    {
        long Id { get; }
        string Name { get; }
        long? Level { get; }
        List<long> Prices { get; }
        List<long> Ranks { get; }
        List<string> Params { get; }
        string ConvertToStringDatabase();
    }
}
