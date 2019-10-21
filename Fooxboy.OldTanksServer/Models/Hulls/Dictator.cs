using Fooxboy.OldTanksServer.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fooxboy.OldTanksServer.Models.Hulls
{
    public class Dictator : IHull
    {
        public long Id => 3;

        public string Name => $"Диктатор М{Level}";

        public long? Level => null;

        public List<long> Prices => new List<long>() {150, 500, 1500, 5000 };

        public List<long> Ranks => new List<long>() { 7, 8, 9, 10};

        public List<long> Healths => new List<long>() {60, 70, 90, 120 };

        public string ConvertToStringDatabase() => $"{Id};{Level.Value};{Healths[Convert.ToInt32(Level.Value)]};";
    }
}
