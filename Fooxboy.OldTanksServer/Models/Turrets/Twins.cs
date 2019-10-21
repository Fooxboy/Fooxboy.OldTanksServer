using Fooxboy.OldTanksServer.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fooxboy.OldTanksServer.Models.Turrets
{
    public class Twins : ITurret
    {
        public long Id => 2;

        public string Name => $"Твинс М{Level}";

        public long? Level => null;

        public List<long> Prices => new List<long> { 10, 50, 150, 500};

        public List<long> Ranks => new List<long> { 4, 5, 7, 9};

        public List<string> Params => new List<string> {"2;m0", "2;m1", "2;m2", "2;m3"};
        public string ConvertToStringDatabase() => $"{Id};{Level.Value};{Params[Convert.ToInt32(Level.Value)]};";
    }
}
