using Fooxboy.OldTanksServer.Interfaces;
using Fooxboy.OldTanksServer.Models.Colormaps;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fooxboy.OldTanksServer.Helpers
{
    public class ColormapBuilder
    {
        public IColormap Build(long id, int type, long price, int rank)
        {
            return new Colormap()
            {
                Id = id,
                Price = price,
                Type = type,
                Rank = rank,
                Resists = new Resist()
            };
        }
    }
}
