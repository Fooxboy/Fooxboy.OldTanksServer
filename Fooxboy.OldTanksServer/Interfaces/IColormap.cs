using Fooxboy.OldTanksServer.Models.Colormaps;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fooxboy.OldTanksServer.Interfaces
{
    public interface IColormap
    {
        long Id { get; set; }
        long Price { get; set; }
        int Type { get; set; }
        Resist Resists { get; set; }
        string ConvertToStringDatabase();
    }
}
