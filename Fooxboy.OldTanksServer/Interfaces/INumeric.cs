using System;
using System.Collections.Generic;
using System.Text;

namespace Fooxboy.OldTanksServer.Interfaces
{
    public interface INumeric
    {
        public long Id { get; set; }
        public long Price { get; set; }
        public long Rank { get; set; }
        string ConvertToStringDatabase();
    }
}
