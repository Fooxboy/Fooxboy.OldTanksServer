using Fooxboy.OldTanksServer.Interfaces;
using Fooxboy.OldTanksServer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fooxboy.OldTanksServer.Helpers
{
    public class NumericHelper
    {
        public List<INumeric> Numerics { get; set; }
        private static NumericHelper _helper;
        public static NumericHelper GetHelper()
        {
            _helper ??= new NumericHelper();
            return _helper;
        }

        private NumericHelper() { }


        public void InitNumerics()
        {
            Numerics = new List<INumeric>();
            Numerics.Add(new Numeric(15, 2, 0));
            Numerics.Add(new Numeric(5, 3, 1));
            Numerics.Add(new Numeric(5, 3, 2));
            Numerics.Add(new Numeric(5, 3, 3));
            Numerics.Add(new Numeric(10, 9, 4));
        }

    }
}
