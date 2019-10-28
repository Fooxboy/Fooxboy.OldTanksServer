using Fooxboy.OldTanksServer.Helpers;
using Fooxboy.OldTanksServer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fooxboy.OldTanksServer.Core
{
    public class SetTank : IRequest
    {
        private readonly Api _api;
        public SetTank(Api api)
        {
            _api = api;
        }
        public string Trigger => "setg";

        public string Execute(List<string> message, Lobby lobby)
        {
            var type = message[1];
            var id = Int32.Parse(message[2]);

            var userGarage = _api.Garage.GetGarageFromId(lobby.User.UserId);

            if(type == "h")
            {
                var hull = HullHelper.GetHelper().GetHullFromId(id);
                if (hull is null) return "error;Указан неверный Id корпуса;";
                if (!(userGarage.Hulls.Any(h => h.Id == hull.Id && h.Level == hull.Level))) return "error;У вас нет в гараже этого корпуса;";
                userGarage.CurrentHull = hull;
            }
            else if(type =="t")
            {
                var turret = TurretHelper.GetHelper().GetTurretFromId(id);
                if (turret is null) return "error;Указан неверный Id башни;";
                if (!(userGarage.Turrets.Any(t => t.Id == turret.Id && t.Level == turret.Level))) return "error;У вас нет в гараже этой башни;";
                userGarage.CurrentTurret = turret;
            }else if(type == "c")
            {
                IColormap color;
                try
                {
                    color = ColormapHelper.GetHelper().Colormaps[id];
                }catch(Exception e)
                {
                    return "error;Указан неизвесный Id краски;";
                }

                if (!(userGarage.Colormaps.Any(c => c.Id == color.Id))) return "error;У вас нет краски в гараже.";
                userGarage.CurrentColormap = ColormapHelper.GetHelper().Colormaps[id];
            }

            _api.Garage.SetGarage(userGarage);
            return $"sett;{lobby.User.Nickname};{lobby.Garage.Crystalls};{HullHelper.GetHelper().GetCurrentHull(userGarage.CurrentHull)};{TurretHelper.GetHelper().GetCurrentTurret(userGarage.CurrentTurret)};{userGarage.CurrentColormap.Id};";

            //throw new NotImplementedException();
        }
    }
}
