using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuruComponents.Netrix
{
    public class NetrixUtils
    {
        /// <summary>
        /// Converts a unit string for example 16px to
        /// a unit
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static System.Web.UI.WebControls.Unit ConvertStringToUnit(string s)
        {
            string number = "";
            string unit = "";

            for (int i = 0; i < s.Length; i++)
            {
                string c = s[i].ToString();
                int current = -1;
                if (Int32.TryParse(c, out current))
                {
                    number += c;
                } else
                {
                    unit += c;
                }
            }

            if (number == "")
            {
                return System.Web.UI.WebControls.Unit.Empty;
            }

            int size = Int32.Parse(number);


            System.Web.UI.WebControls.UnitType unitType = System.Web.UI.WebControls.UnitType.Point;

            if (unit == "px") unitType = System.Web.UI.WebControls.UnitType.Pixel;
            if (unit == "pt") unitType = System.Web.UI.WebControls.UnitType.Point;
            if (unit == "em") unitType = System.Web.UI.WebControls.UnitType.Em;
            if (unit == "%") unitType = System.Web.UI.WebControls.UnitType.Percentage;

            System.Web.UI.WebControls.Unit webUnit = new System.Web.UI.WebControls.Unit(size, unitType);
            return webUnit;
        }
    }
}
