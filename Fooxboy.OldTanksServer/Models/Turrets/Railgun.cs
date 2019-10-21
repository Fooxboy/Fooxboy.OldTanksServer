using Fooxboy.OldTanksServer.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fooxboy.OldTanksServer.Models.Turrets
{
    public class Railgun : ITurret
    {
        public long Id => 3;

        public string Name => $"Рельса М{Level}";

        public long? Level => null;

        public List<long> Prices => new List<long>() {100, 350, 1100, 3700 };

        public List<long> Ranks => new List<long>() {6, 7, 8, 9 };

        public List<string> Params => new List<string>() {"3;m0", "3;m1", "3;m2", "3;m3" };
        public string ConvertToStringDatabase() => $"{Id};{Level.Value};{Params[Convert.ToInt32(Level.Value)]};";
    }
}
