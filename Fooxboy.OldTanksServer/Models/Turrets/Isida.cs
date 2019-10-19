using Fooxboy.OldTanksServer.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fooxboy.OldTanksServer.Models.Turrets
{
    public class Isida : ITurret
    {
        public long Id => 4;

        public string Name => $"Изида М{Level}";

        public long? Level => null;

        public List<long> Prices => new List<long>() {300, 700, 1800, 4500 };

        public List<long> Ranks => new List<long>() {8, 9, 10, 12 };

        public List<string> Params => new List<string>() {"4;m0", "4;m1", "4;m2", "4;m3"  };
    }
}
