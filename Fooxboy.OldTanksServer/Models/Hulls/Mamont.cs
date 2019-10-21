using Fooxboy.OldTanksServer.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fooxboy.OldTanksServer.Models.Hulls
{
    public class Mamont : IHull
    {
        public long Id => 6;

        public string Name => $"Мамонт М{Level}";

        public long? Level  { get; set; }

        public List<long> Prices => new List<long>() {750, 2250, 6800, 20400 };

        public List<long> Ranks => new List<long>() { 12, 13, 14, 15};

        public List<long> Healths => new List<long>() {130, 142, 165, 200 };
        public string ConvertToStringDatabase() => $"{Id};{Level.Value};{Healths[Convert.ToInt32(Level.Value)]};";
    }
}
