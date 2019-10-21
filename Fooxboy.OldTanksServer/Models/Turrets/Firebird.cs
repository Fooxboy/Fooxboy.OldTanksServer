using Fooxboy.OldTanksServer.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fooxboy.OldTanksServer.Models.Turrets
{
    public class Firebird : ITurret
    {
        public long Id => 1;

        public string Name => $"Огнемёт М{Level}";

        public long? Level { get; set; }

        public List<long> Prices => new List<long>() {5, 40, 120, 400 };

        public List<long> Ranks => new List<long>() {3, 4, 6, 8 };

        public List<string> Params => new List<string>() {"1;m0", "1;m1", "1;m2", "1;m3" };
        public string ConvertToStringDatabase() => $"{Id};{Level.Value};{Params[Convert.ToInt32(Level.Value)]};";
    }
}
