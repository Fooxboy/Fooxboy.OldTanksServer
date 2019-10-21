using Fooxboy.OldTanksServer.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fooxboy.OldTanksServer.Models.Turrets
{
    public class Ricochet : ITurret
    {
        public long Id => 7;

        public string Name => $"Рикошет М{Level}";

        public long? Level { get; set; }

        public List<long> Prices => new List<long>() { 655, 2000, 6000, 18000};

        public List<long> Ranks => new List<long>() {13, 14, 15, 16 };

        public List<string> Params => new List<string>() {"2;m4", "2;m5", "2;m6", "2;m7"  };
        public string ConvertToStringDatabase() => $"{Id};{Level.Value};{Params[Convert.ToInt32(Level.Value)]};";
    }
}
