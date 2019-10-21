using Fooxboy.OldTanksServer.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Fooxboy.OldTanksServer.Models
{
    public class Garage
    {
        [Key]
        public long UserId { get; set; }
        public long Crystalls { get; set; }
        public long Score { get; set; }
        public string ListHullsString { get; set; }
        public string ListTurretsString { get; set; }
        public string ListColormapsString { get; set; }
        public string ListNumericsString { get; set; }
        public string CurrentHullString { get; set; }
        public string CurrentTurretString { get; set; }
        public string CurrentColormapString { get; set; }
        [NotMapped]
        public List<IHull> Hulls { get; set; }
        [NotMapped]
        public List<ITurret> Turrets { get; set; }
        [NotMapped]
        public List<IColormap> Colormaps { get; set; }
        [NotMapped]
        public List<INumeric> Numerics { get; set; }
        [NotMapped]
        public IHull CurrentHull { get; set; }
        [NotMapped]
        public ITurret CurrentTurret { get; set; }
        [NotMapped]
        public IColormap CurrentColormap { get; set; }
    }
}
