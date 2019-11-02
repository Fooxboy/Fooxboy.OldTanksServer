using Fooxboy.OldTanksServer.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace Fooxboy.OldTanksServer.Helpers
{
    public class GarageHelper
    {
        private static GarageHelper _helper;
        private GarageHelper() { }

        public static GarageHelper GetHelper()
        {
            _helper ??= new GarageHelper();
            return _helper;
        }


        public string GetGarageString(Garage garage)
        {
            var str = string.Empty;
            var rank = RankHelper.GetHelper().GetRankFromScore(garage.Score);
            var numericsList = new List<string>();
            var turretsList = new List<string>();
            var hullsList = new List<string>();
            var colormapList = new List<string>();

            var numCounts = new List<int>() { 0, 0, 0, 0, 0 };
            foreach(var numeric in garage.Numerics) numCounts[Convert.ToInt32(numeric.Id)] += 1;
            foreach(var numCount in numCounts)
            {
                numericsList.Add($"{numCount};1");
            }

            foreach(var turret in TurretHelper.GetHelper().Turrets)
            {
                var isBuy = garage.Turrets.Any(t => t.Id == turret.Id) ? 1 : 0;
                var levelValue = garage.Turrets.Any(t => t.Id == turret.Id) ? garage.Turrets.Single(t => t.Id == turret.Id).Level : -1;
                var isAvailable = garage.Turrets.Any(t => t.Id == turret.Id) ? (rank >= turret.Ranks[Convert.ToInt32(garage.Turrets.Single(t => t.Id == turret.Id).Level)] ? 1 : 0) : (rank >= turret.Ranks[0] ? 1 : 0);
                var isCurrentTurret = garage.CurrentTurret.Id == turret.Id ? 1 : 0;
                turretsList.Add($"{isBuy};{levelValue};{isAvailable};{levelValue};{isCurrentTurret}");
            }

            foreach(var hull in HullHelper.GetHelper().Hulls)
            {
                var isBuy = garage.Hulls.Any(h => h.Id == hull.Id) ? 1 : 0;
                var level = garage.Hulls.Any(h => h.Id == hull.Id) ? garage.Hulls.Single(h => h.Id == hull.Id).Level : -1;
                var isAvailable = garage.Hulls.Any(h => h.Id == hull.Id) ? (rank >= hull.Ranks[Convert.ToInt32(garage.Hulls.Single(h=> h.Id == h.Id).Level)]? 1 : 0) : (rank>= hull.Ranks[0]? 1:0);
                var isCurrentHull = garage.CurrentHull.Id == hull.Id ? 1 : 0;
                hullsList.Add($"{isBuy};{level};{isAvailable};{level};{isCurrentHull}");
            }

            foreach(var colormap in ColormapHelper.GetHelper().Colormaps)
            {
                var isBuy = garage.Colormaps.Any(c=> c.Id == colormap.Id)? 1:0;
                var isAvailable = rank >= colormap.Rank ? 1 : 0;
                var isCurrentColormap = garage.CurrentColormap.Id == colormap.Id ? 1 : 0;

                colormapList.Add($"{isBuy};{colormap.Id};{isAvailable}:{isCurrentColormap}");
            }

            str = $"garr;5;8;7;56;";
            foreach(var num in numericsList) str += num + ";";
            foreach (var turret in turretsList) str += turret + ";";
            foreach (var hull in hullsList) str += hull + ";";

            return str;
        }
    }
}
