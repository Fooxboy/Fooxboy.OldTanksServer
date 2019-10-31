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
                int isBuy = garage.Turrets.Any(t => t.Id == turret.Id) ? 1 : 0;
                var idTurret = TurretHelper.GetHelper().GetCurrentTurret(turret);
                var isAvailable = rank >= turret.Ranks[Convert.ToInt32(turret.Id)] ? 1 : 0;
                var isCurrentTurret = garage.CurrentTurret.Id == turret.Id ? 1 : 0; ;
                turretsList.Add($"{isBuy};{idTurret};{isAvailable};{idTurret};{isCurrentTurret}");
            }

            foreach(var hull in HullHelper.GetHelper().Hulls)
            {

            }
        }
    }
}
