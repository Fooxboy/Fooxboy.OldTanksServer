using Fooxboy.OldTanksServer.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fooxboy.OldTanksServer.Models.Hulls
{
    public class Viking : IHull
    {
        public long Id => 5;

        public string Name => $"Викинг М{Level}";

        public long? Level => null;

        public List<long> Prices => new List<long>() { 600, 1800, 5400, 16200};

        public List<long> Ranks => new List<long>() { 10, 12, 13, 14};

        public List<long> Healths => new List<long>() { 100, 109, 125, 150};
        public string ConvertToStringDatabase() => $"{Id};{Level.Value};{Healths[Convert.ToInt32(Level.Value)]};";
    }
}
