using Fooxboy.OldTanksServer.Helpers;
using Fooxboy.OldTanksServer.Interfaces;
using Fooxboy.OldTanksServer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fooxboy.OldTanksServer.Core
{
    public class BuyGarage : IRequest
    {
        private readonly Api _api;
        public BuyGarage(Api api)
        {
            _api = api;
        }
        public string Trigger => "buyg";

        public string Execute(List<string> message, Lobby lobby)
        {
            var type = message[1];
            var itemId = Int32.Parse(message[2]);
            var count = type=="n"? Int32.Parse(message[3]): 0;
            var userRank = RankHelper.GetHelper().GetRankFromScore(lobby.Garage.Score);
            var garage = lobby.Garage;
            if (type =="h")
            {
                var hull = HullHelper.GetHelper().GetHullFromId(itemId);
                if (hull.Prices[Convert.ToInt32(hull.Level.Value)] > lobby.Garage.Crystalls) return "error;У вас недостаточно кристалов;";
                if (hull.Ranks[Convert.ToInt32(hull.Level.Value)] > userRank) return "error;У вас слишком маленькое звание.";
                if (garage.Hulls.Any(h => h.Id == hull.Id && h.Level == hull.Level)) return "error;У вас уже куплен этот корпус";

                if (garage.Hulls.Any(h => h.Id == hull.Id))
                {
                    var hullBuy = garage.Hulls.Single(h => h.Id == hull.Id);
                    garage.Hulls.Remove(hullBuy);
                }
                garage.Hulls.Add(hull);
                garage.Crystalls -= hull.Prices[(Convert.ToInt32(hull.Level.Value))];
            }else if(type == "t")
            {
                var turret = TurretHelper.GetHelper().GetTurretFromId(itemId);
                if (turret.Prices[Convert.ToInt32(turret.Level.Value)] > garage.Crystalls) return "error;У вас недостаточно кристалов;";
                if (turret.Ranks[Convert.ToInt32(turret.Level.Value)] > userRank) return "error;У вас слишком маленькое звание.";
                if (garage.Turrets.Any(t => t.Id == turret.Id && t.Level == turret.Level)) return "error;У вас уже куплена эта башня";
                if (garage.Turrets.Any(t => t.Id == turret.Id))
                {
                    var turretBuy = garage.Turrets.Single(t => t.Id == turret.Id);
                    garage.Turrets.Remove(turretBuy);
                }

                garage.Turrets.Add(turret);
                garage.Crystalls -= turret.Prices[(Convert.ToInt32(turret.Level.Value))];
            }else if(type == "c")
            {
                var colormap = ColormapHelper.GetHelper().Colormaps[itemId];
                if (colormap.Price > garage.Crystalls) return "error;У вас недостаточно кристалов;";
                if (colormap.Rank > userRank) return "error;У вас слишком маленькое звание.";
                if (garage.Colormaps.Any(c => c.Id == colormap.Id)) return "error;У вас уже куплен эта краска";
                garage.Colormaps.Add(colormap);
                garage.Crystalls -= colormap.Price;
            }else if(type == "n")
            {
                if (itemId > NumericHelper.GetHelper().Numerics.Count - 1) return "error;id слишком большое;";
                var numeric = NumericHelper.GetHelper().Numerics[itemId];
                var price = numeric.Price * count;
                if (garage.Crystalls < price) return "error;У Вас недостатточно кристаллов.;";
                if (userRank < numeric.Rank) return "error;У вас слишком маленькое звание;";
                for (var i= 0; i > count; i++ ) garage.Numerics.Add(numeric);
            }

            _api.Garage.SetGarage(garage);
            return $"sett;{lobby.User.Nickname}";
        }
    }
}
