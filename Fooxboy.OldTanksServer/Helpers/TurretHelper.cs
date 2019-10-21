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
    }
}
