using Fooxboy.OldTanksServer.Helpers;
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
        public string ListHullsString
        {
            get => HullHelper.GetHelper().ConvertListModelToListString(Hulls);
            set => Hulls = HullHelper.GetHelper().ConvertListStringToListModel(value);
        }
        public string ListTurretsString
        {
            get => TurretHelper.GetHelper().ConvertListModelToListString(Turrets);
            set => Turrets = TurretHelper.GetHelper().ConvertListStringToListModel(value);
        }
        public string ListColormapsString
        {
            get => ColormapHelper.GetHelper().ConvertListModelToListString(Colormaps);
            set => Colormaps = ColormapHelper.GetHelper().ConvertListStringToListModel(value);
        }
        public string ListNumericsString { get; set; }
        public string CurrentHullString
        {
            get => CurrentHull.ConvertToStringDatabase();
            set => CurrentHull = HullHelper.GetHelper().ConvertStringToModel(value);
        }
        public string CurrentTurretString
        {
            get => CurrentTurret.ConvertToStringDatabase();
            set => CurrentTurret = TurretHelper.GetHelper().ConvertStringToModel(value);
        }
        public string CurrentColormapString
        {
            get => ColormapHelper.GetHelper().ConvertModelToString(CurrentColormap);
            set => CurrentColormap = ColormapHelper.GetHelper().ConvertStringToModel(value);
        }
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
