using Fooxboy.OldTanksServer.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fooxboy.OldTanksServer.Models.Hulls
{
    public class Hornet : IHull
    {
        public long Id => 4;

        public string Name => $"Хорнет М{Level}";

        public long? Level => null;

        public List<long> Prices => new List<long>() {450, 1350, 4000, 12000 };

        public List<long> Ranks => new List<long>() {9, 10, 12, 13 };

        public List<long> Healths => new List<long>() { 65, 71, 83, 100};
    }
}
