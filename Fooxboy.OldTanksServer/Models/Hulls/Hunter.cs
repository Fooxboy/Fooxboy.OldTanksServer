using Fooxboy.OldTanksServer.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fooxboy.OldTanksServer.Models.Hulls
{
    public class Hunter : IHull
    {
        public long Id => 1;

        public string Name => $"Хантер М{Level}";

        public long? Level { get; set; }

        public List<long> Prices => new List<long>() {10, 70, 210 };

        public List<long> Healths => new List<long>() { 45, 53, 68, 90};

        public List<long> Ranks => new List<long>() { 2, 3, 5, 7 };
        public string ConvertToStringDatabase() => $"{Id};{Level.Value};{Healths[Convert.ToInt32(Level.Value)]};";
    }
}
