using Fooxboy.OldTanksServer.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fooxboy.OldTanksServer.Models.Turrets
{
    public class Smoky : ITurret
    {
        public long Id => 0;

        public string Name => $"Смоки М{Level}";

        public long? Level => null;

        public List<long> Prices => new List<long> { 0, 30, 90, 300};

        public List<long> Ranks => new List<long> { 0, 2, 4, 6};

        public List<string> Params => new List<string> { "0;m0", "0;m1", "0;m2", "0;m3"};
    }
}
