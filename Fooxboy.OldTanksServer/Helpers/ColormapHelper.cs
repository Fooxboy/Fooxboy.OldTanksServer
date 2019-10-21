using Fooxboy.OldTanksServer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fooxboy.OldTanksServer.Helpers
{
    public class ColormapHelper
    {
        private static ColormapHelper _helper;

        private ColormapHelper() { }
        public List<IColormap> Colormaps { get; set; }
        public static ColormapHelper GetHelper()
        {
            _helper ??= new ColormapHelper();
            return _helper;
        }

        public string ConvertModelToString(IColormap colormap) => $"{colormap.Id};";

        public void InitColormaps(params IColormap[] colormaps)
        {
            Colormaps = colormaps.ToList();
        }

        public IColormap ConvertStringToModel(string modelString)
        {
            var array = modelString.Split(";");
            return Colormaps.Single(c => c.Id == Int64.Parse(array[0]));
        }

        public string ConvertListModelToListString(List<IColormap> colormaps)
        {
            var resultString = string.Empty;
            foreach (var model in colormaps) resultString += $"{ConvertModelToString(model)}&";
            return resultString;
        }

        public List<IColormap> ConvertListStringToListModel(string colormapsString)
        {
            var result = new List<IColormap>();
            var array = colormapsString.Split("&");
            foreach (var model in array) result.Add(ConvertStringToModel(model));
            return result;
        }

    }
}
