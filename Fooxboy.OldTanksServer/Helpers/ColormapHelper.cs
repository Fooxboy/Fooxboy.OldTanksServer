using Fooxboy.OldTanksServer.Interfaces;
using Fooxboy.OldTanksServer.Models.Colormaps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fooxboy.OldTanksServer.Helpers
{
    public class ColormapHelper
    {
        private static ColormapHelper _helper;
        private readonly ColormapBuilder _builder;
        private ColormapHelper() { _builder = new ColormapBuilder(); }
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

        public void InitColormaps()
        {
            InitColormaps(_builder.Build(0, 1, 0, 0), _builder.Build(1, 1, 0, 0), _builder.Build(2, 0, 0, 0),
                _builder.Build(3, 0, 0, 0), _builder.Build(4, 0, 5, 1), _builder.Build(5, 0, 5, 1), 
                _builder.Build(6, 0, 10,2), _builder.Build(7, 0, 10, 2), _builder.Build(8, 0, 100, 3),
                _builder.Build(9, 0, 50, 3), _builder.Build(10, 0, 50, 3), _builder.Build(11, 0, 100, 3),
                _builder.Build(12, 0, 100, 3), _builder.Build(13, 0, 50, 3), _builder.Build(14,0, 200, 4),
                _builder.Build(15, 0, 200,4), _builder.Build(16, 0, 200, 4), _builder.Build(17, 0, 200, 4),
                _builder.Build(18, 0, 500, 5), _builder.Build(19, 0, 500, 5), _builder.Build(20, 0, 500, 5),
                _builder.Build(21, 0, 1000, 6), _builder.Build(22, 0, 1000, 6), _builder.Build(23, 0, 1000, 6),
                _builder.Build(24, 0, 3000, 7), _builder.Build(25, 0, 3000, 7), _builder.Build(26, 0, 3000, 7),
                _builder.Build(27, 0, 8000, 8), _builder.Build(28, 0, 8000, 8), _builder.Build(29, 0, 8000, 8),
                _builder.Build(30, 0, 2000, 9), _builder.Build(31, 0, 2000, 9), _builder.Build(32, 0, 12000, 9),
                _builder.Build(33, 0, 2000, 10), _builder.Build(34, 0, 5000, 10), _builder.Build(35, 0, 5000, 11),
                _builder.Build(36, 0, 5000, 11), _builder.Build(37, 0, 12000, 11), _builder.Build(38, 0, 12000, 12),
                _builder.Build(39, 0, 7000, 12), _builder.Build(40, 0, 7000, 12), _builder.Build(41, 0, 7000, 12),
                _builder.Build(42, 0, 7000, 12), _builder.Build(43, 0, 1000, 13), _builder.Build(44, 0, 10000, 13),
                _builder.Build(45, 0, 10000, 13), _builder.Build(46, 0, 10000, 13), _builder.Build(47, 0, 10000, 13),
                _builder.Build(48, 0, 15000, 14), _builder.Build(49, 0, 15000, 14), _builder.Build(50, 0, 15000, 14),
                _builder.Build(51, 0, 15000, 14), _builder.Build(52, 0, 0, 19), _builder.Build(53, 0, 0, 19),
                _builder.Build(54, 0, 0, 19), _builder.Build(55, 0, 0, 19));
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
