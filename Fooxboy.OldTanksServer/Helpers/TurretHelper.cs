using Fooxboy.OldTanksServer.Interfaces;
using Fooxboy.OldTanksServer.Models.Turrets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fooxboy.OldTanksServer.Helpers
{
    public class TurretHelper
    {
        private static TurretHelper _helper;
        public List<ITurret> Turrets { get; set; }

        private TurretHelper()
        {

        }

        public static TurretHelper GetHelper()
        {
            _helper ??= new TurretHelper();
            return _helper;
        }

        public void InitTurrets(params ITurret[] turrets)
        {
            Turrets = turrets.ToList();
        }

        public void InitTurrets()
        {
            InitTurrets(new Firebird(), new Freeze(), new Isida(), new Railgun(), new Ricochet(), new Smoky(), new Thunder(), new Twins());
        }

        public ITurret ConvertStringToModel(string modelString)
        {
            var array = modelString.Split(";");
            var model = Turrets.Single(t => t.Id == Int64.Parse(array[0]));
            model.Level = Int64.Parse(array[1]);
            return model;
        }

        public List<ITurret> ConvertListStringToListModel(string modelsString)
        {
            var array = modelsString.Split("&");
            List<ITurret> result = new List<ITurret>();
            foreach (var model in array) result.Add(ConvertStringToModel(model));
            return result;
        }

        public string ConvertListModelToListString(List<ITurret> models)
        {
            var resultString = string.Empty;
            foreach (var model in models) resultString += $"{model.ConvertToStringDatabase()}&";
            return resultString;
        }

        public ITurret GetTurretFromId(int id)
        {
            //Пиздец дикий говнокод, но я не виноват, что клиент писал ебанутый имбицил, и теперь id предметов разные.
            var tId = 0;
            var lvl = 0;



            if (id == 0)
            {
                lvl = 0;
            }
            else if (id == 1)
            {
                lvl = 1;
            }
            else if (id == 2)
            {
                lvl = 2;
            }
            else if (id == 3)
            {
                lvl = 3;
            }
            else if (id == 4)
            {
                tId = 1;
                lvl = 0;
            }
            else if (id == 5)
            {
                tId = 1;
                lvl = 1;
            }
            else if (id == 6)
            {
                tId = 1;
                lvl = 2;
            }
            else if (id == 7)
            {
                tId = 1;
                lvl = 3;
            }
            else if (id == 8)
            {
                tId = 2;
                lvl = 0;
            }
            else if (id == 9)
            {
                tId = 2;
                lvl = 1;
            }
            else if (id == 10)
            {
                tId = 2;
                lvl = 2;
            }
            else if (id == 11)
            {
                tId = 2;
                lvl = 3;
            }
            else if (id == 12)
            {
                tId = 3;
                lvl = 0;
            }
            else if (id == 13)
            {
                tId = 3;
                lvl = 1;
            }
            else if (id == 14)
            {
                tId = 3;
                lvl = 2;
            }
            else if (id == 15)
            {
                tId = 3;
                lvl = 3;
            }
            else if (id == 16)
            {
                tId = 4;
                lvl = 0;
            }
            else if (id == 17)
            {
                tId = 4;
                lvl = 1;
            }
            else if (id == 18)
            {
                tId = 4;
                lvl = 2;
            }
            else if (id == 19)
            {
                tId = 4;
                lvl = 3;
            }
            else if (id == 20)
            {
                tId = 5;
                lvl = 0;
            }
            else if (id == 21)
            {
                tId = 5;
                lvl = 1;
            }
            else if (id == 22)
            {
                tId = 5;
                lvl = 2;
            }
            else if (id == 23)
            {
                tId = 5;
                lvl = 3;
            } else if (id == 24)
            {
                tId = 6;
                lvl = 0;
            } else if (id == 25)
            {
                tId = 6;
                lvl = 1;
            } else if (id == 26)
            {
                tId = 6;
                lvl = 2;
            }else if(id == 27)
            {
                tId = 6;
                lvl = 3;
            }else if(id == 28)
            {
                tId = 7;
                lvl = 0;
            }else if(id == 29)
            {
                tId = 7;
                lvl = 1;
            }else if(id == 30)
            {
                tId = 7;
                lvl = 2;
            }else if(id == 31)
            {
                tId = 7;
                lvl = 3;
            }

            var turret = Turrets.Single(t => t.Id == tId);
            if (turret != null) turret.Level = lvl;
        }

        public long GetCurrentTurret(ITurret turret) => (turret.Level.Value + turret.Id) + turret.Id * 3;
    }
}
