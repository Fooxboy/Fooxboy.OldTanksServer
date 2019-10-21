using Fooxboy.OldTanksServer.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fooxboy.OldTanksServer.Models.Turrets
{
    public class Freeze : ITurret
    {
        public long Id => 6;

        public string Name => $"Фриз М{Level}";

        public long? Level { get; set; }

        public List<long> Prices => new List<long>() { 550, 1700, 5000, 1500};

        public List<long> Ranks => new List<long>() {12, 13, 14, 15 };

        public List<string> Params => new List<string>() {"1;m4", "1;m5", "1;m6", "1;m7" };
        public string ConvertToStringDatabase() => $"{Id};{Level.Value};{Params[Convert.ToInt32(Level.Value)]};";
    }
}
