using Fooxboy.OldTanksServer.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fooxboy.OldTanksServer.Models
{
    public class Numeric : INumeric
    {
        public Numeric(long price, long rank, long id)
        {
            Price = price;
            Rank = rank;
            Id = id;
        }
        public long Id { get; set; }
        public long Price { get; set; }
        public long Rank { get; set; }

        public string ConvertToStringDatabase() => $"{Id};{Price};{Rank};";
    }
}
