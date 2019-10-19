using Fooxboy.OldTanksServer.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fooxboy.OldTanksServer.Models.Turrets
{
    public class Thunder : ITurret
    {
        public long Id => 5;

        public string Name => $"Гром М{Level}";

        public long? Level => null;

        public List<long> Prices => new List<long>() {500, 1500, 4500, 14000 };

        public List<long> Ranks => new List<long>() {10, 12, 13, 14 };

        public List<string> Params => new List<string>() { "0;m4", "0;m5", "0;m6", "0;m7"};
    }
}
