using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace ConsultaPessoa.Commons
{
    public class Utils
    {
        public static System.Object ToBooleanNull(System.Int32 AValue)
        {
            if (AValue == 2)
            {
                return DBNull.Value;
            }
            else
            {
                return AValue == 1;
            }
        }
        public static System.Object ToIntNull(System.Int32 AValue)
        {
            if (AValue == 0)
            {
                return DBNull.Value;
            }
            else
            {
                return AValue;
            }
        }
        public static int ToInt32(string value)
        {
            if (value == null || value == "")
            {
                return 0;
            }
            return int.Parse(value, CultureInfo.CurrentCulture);
        }
    }
}
