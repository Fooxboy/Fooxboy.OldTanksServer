using Fooxboy.OldTanksServer.Interfaces;
using Fooxboy.OldTanksServer.Models.Hulls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;

namespace Fooxboy.OldTanksServer.Helpers
{
    public class HullHelper
    {
        private static HullHelper _helper;
        public List<IHull> Hulls { get; set; }

        private HullHelper()
        {

        }

        public static HullHelper GetHelper()
        {
            _helper ??= new HullHelper();
            return _helper;
        }

        public void InitHulls(params IHull[] hulls )
        {
            Hulls = hulls.ToList();
        }

        public void InitHulls()
        {
            InitHulls(new Dictator(), new Hornet(), new Hunter(), new Mamont(), new Titan(), new Viking(), new Wasp());
        }

        public IHull ConvertStringToModel(string modelString)
        {
            var array = modelString.Split(";");
            var model = Hulls.Single(h => h.Id == Int64.Parse(array[0]));
            model.Level = Int64.Parse(array[1]);
            return model;
        }

        public List<IHull> ConvertListStringToListModel(string modelsString)
        {
            var array = modelsString.Split("&");
            List<IHull> result = new List<IHull>();
            foreach (var model in array) result.Add(ConvertStringToModel(model));
            return result;
        }

        public IHull GetHullFromId(int id)
        {
            //Пиздец дикий говнокод, но я не виноват, что клиент писал ебанутый имбицил, и теперь id предметов разные.
            var level = 0;
            var hullId = 0;

            if (id == 0)
            {
                level = 0;
            } else if (id == 1)
            {
                level = 1;
            } else if (id == 2)
            {
                level = 2;
            } else if (id == 3)
            {
                level = 3;
            } else if (id == 4)
            {
                hullId = 1;
                level = 0;
            } else if (id == 5)
            {
                hullId = 1;
                level = 1;
            } else if (id == 6)
            {
                hullId = 1;
                level = 2;
            } else if (id == 7)
            {
                hullId = 1;
                level = 3;
            } else if (id == 8)
            {
                hullId = 2;
                level = 0;
            } else if (id == 9)
            {
                hullId = 2;
                level = 1;
            } else if (id == 10)
            {
                hullId = 2;
                level = 2;
            } else if (id == 11)
            {
                hullId = 3;
                level = 3;
            } else if (id == 12)
            {
                hullId = 4;
                level = 0;
            } else if (id == 13)
            {
                hullId = 4;
                level = 1;
            } else if (id == 14)
            {
                hullId = 4;
                level = 2;
            } else if (id == 15)
            {
                hullId = 4;
                level = 3;
            } else if (id == 16)
            {
                hullId = 5;
                level = 0;
            }else if(id == 17)
            {
                hullId = 5;
                level = 1;
            }else if(id == 18)
            {
                hullId = 5;
                level = 2;
            }else if(id == 19)
            {
                hullId = 5;
                level = 3;
            }else if(id == 20)
            {
                hullId = 6;
                level = 0;
            }else if(id == 21)
            {
                hullId = 6;
                level = 1;
            }else if(id ==22)
            {
                hullId = 6;
                level = 2;
            }else if(id == 23)
            {
                hullId = 6;
                level = 3;
            }else if(id == 24)
            {
                hullId = 7;
                level = 0;
            }else if(id == 25)
            {
                hullId = 7;
                level = 1;
            }else if(id == 26)
            {
                hullId = 7;
                level = 2;
            }else if(id == 27)
            {
                hullId = 7;
                level = 3;
            }

            var hull = Hulls.Single(h => h.Id == id);
            if (hull != null) hull.Level = level;
            return hull;
            //var a = id / 3;
        }

        public string ConvertListModelToListString(List<IHull> models)
        {
            var resultString = string.Empty;
            foreach(var model in models) resultString += $"{model.ConvertToStringDatabase()}&";
            return resultString;
        }

        public long GetCurrentHull(IHull hull) => (hull.Level.Value + hull.Id) + hull.Id * 3;
    }
}
