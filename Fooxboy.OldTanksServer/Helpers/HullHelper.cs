using Fooxboy.OldTanksServer.Interfaces;
using Fooxboy.OldTanksServer.Models.Hulls;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public string ConvertListModelToListString(List<IHull> models)
        {
            var resultString = string.Empty;
            foreach(var model in models) resultString += $"{model.ConvertToStringDatabase()}&";
            return resultString;
        }
    }
}
