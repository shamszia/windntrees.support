using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Core
{
    public static class Util
    {
        public static Nullable<DateTime> ConvertToDateTime(object data)
        {
            if (data == DBNull.Value)
            {
                return null;
            }
            return Convert.ToDateTime(data);
        }

        public static DateTime ConvertToDateTime(object data, DateTime optedValue)
        {
            if (data == DBNull.Value)
            {
                return optedValue;
            }
            return Convert.ToDateTime(data);
        }

        public static Nullable<Int32> ConvertToInt32(object data)
        {
            if (data == DBNull.Value)
            {
                return null;
            }
            return Convert.ToInt32(data);
        }

        public static Int32 ConvertToInt32(object data, Int32 optedValue)
        {
            if (data == DBNull.Value)
            {
                return optedValue;
            }
            return Convert.ToInt32(data);
        }

        public static Nullable<Int64> ConvertToInt64(object data)
        {
            if (data == DBNull.Value)
            {
                return null;
            }
            return Convert.ToInt64(data);
        }

        public static Int64 ConvertToInt64(object data, Int64 optedValue)
        {
            if (data == DBNull.Value)
            {
                return optedValue;
            }
            return Convert.ToInt64(data);
        }

        public static Nullable<Decimal> ConvertToDecimal(object data)
        {
            if (data == DBNull.Value)
            {
                return null;
            }
            return Convert.ToDecimal(data);
        }

        public static Decimal ConvertToDecimal(object data, decimal optedValue)
        {
            if (data == DBNull.Value)
            {
                return optedValue;
            }
            return Convert.ToDecimal(data);
        }

        public static Nullable<bool> ConvertToBoolean(object data)
        {
            if (data == DBNull.Value)
            {
                return null;
            }
            return Convert.ToBoolean(data);
        }

        public static bool ConvertToBoolean(object data, bool optedValue)
        {
            if (data == DBNull.Value)
            {
                return optedValue;
            }
            return Convert.ToBoolean(data);
        }
    }
}
