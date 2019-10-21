using Fooxboy.OldTanksServer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public IHull ConvertStringToModel(string modelString)
        {
            var array = modelString.Split(";");
            var model = Hulls.Single(h => h.Id == Int64.Parse(array[0]));
            model.Level = Int64.Parse(array[1]);
        }
    }
}
