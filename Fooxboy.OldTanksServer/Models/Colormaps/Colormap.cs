using Fooxboy.OldTanksServer.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fooxboy.OldTanksServer.Models.Colormaps
{
    public class Colormap:IColormap
    {
        public long Id { get; set; }
        public int Rank { get; set; }
        public long Price { get; set; }
        public int Type { get; set; }
        public Resist Resists { get; set; }

        public string ConvertToStringDatabase()
        {
            return $"{Id};";
        }
    }
}
