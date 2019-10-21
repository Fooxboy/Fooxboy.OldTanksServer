using Fooxboy.OldTanksServer.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fooxboy.OldTanksServer.Models.Hulls
{
    public class Wasp : IHull
    {
        public long Id => 0;
        public string Name => $"Васп М{Level}";
        public long? Level { get; set; }
        public List<long> Prices => new List<long>() {0, 50, 150, 500 };
        public List<long> Ranks => new List<long>() { 0, 2, 4, 6 };
        public List<long> Healths => new List<long>() {30, 35, 45, 60 };

        public override string ToString()
        {
            return $"Корпус: {Name}, ID: {Id}, Уровень: {Level}";
        }
        public string ConvertToStringDatabase() => $"{Id};{Level.Value};{Healths[Convert.ToInt32(Level.Value)]};";
    }
}
