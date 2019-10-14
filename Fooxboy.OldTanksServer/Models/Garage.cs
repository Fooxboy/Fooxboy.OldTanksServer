using Fooxboy.OldTanksServer.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fooxboy.OldTanksServer.Models
{
    public class Garage
    {
        public long Crystalls { get; set; }
        public long Score { get; set; }
        public List<IHull> Hulls { get; set; }
        public List<ITurret> Turrets { get; set; }
        public List<IColormap> Colormaps { get; set; }
        public List<INumeric> Numerics { get; set; }
        public IHull CurrentHull { get; set; }
        public ITurret CurrentTurret { get; set; }
        public IColormap CurrentColormap { get; set; }
    }
}
