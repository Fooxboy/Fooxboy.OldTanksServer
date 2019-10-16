using Fooxboy.OldTanksServer.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fooxboy.OldTanksServer.Models.Hulls
{
    public class Titan : IHull
    {
        public long Id => 2;

        public string Name => $"Титан  М{Level.Value}";

        public long? Level => null;

        public List<long> Prices => new List<long>() {20, 100, 300, 900 };

        public List<long> Ranks => new List<long>() {3, 4, 6, 8 };

        public List<long> Healths => new List<long>() {60, 70, 90, 120 };
    }
}
