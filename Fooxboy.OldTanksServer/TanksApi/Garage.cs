using Fooxboy.OldTanksServer.Database;
using Fooxboy.OldTanksServer.Interfaces.TanksApi;
using Fooxboy.OldTanksServer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fooxboy.OldTanksServer.TanksApi
{
    public class Garage : IGarage
    {
        public Models.Garage GetGarageFromId(long userId)
        {
            using var db = new ServerDB();
            return db.Garages.Single(g => g.UserId == userId);
        }

        public Models.Garage GetGarageFromNickname(string nickname)
        {
            using var db = new ServerDB();
            var user = db.Users.Single(u => u.Nickname == nickname);
            return db.Garages.Single(g => g.UserId == user.UserId);
        }

        public bool Register(long userId)
        {
            using var db = new ServerDB();
            try
            {
                db.Garages.Add(new Models.Garage()
                {
                    UserId = userId,
                    Colormaps = new List<Interfaces.IColormap>(),
                    Crystalls = 0,
                    CurrentColormap = null,
                    CurrentHull = null,
                    CurrentTurret = null,
                    Hulls = new List<Interfaces.IHull>(),
                    Numerics = new List<Interfaces.INumeric>(),
                    Score = 0,
                    Turrets = new List<Interfaces.ITurret>()
                });
                db.SaveChanges();
                return true;
            }catch(Exception e)
            {
                return false;
            }
            
        }

        public bool SetGarage(Models.Garage garage)
        {
            using var db = new ServerDB();
            try
            {
                var currentGarage = db.Garages.Single(g => g.UserId == garage.UserId);
                currentGarage = garage;
                db.SaveChanges();
                return true;
            }catch(Exception e)
            {
                return false;
            }
        }
    }
}
