using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace ChunkyConsoleCore.Utils
{
    public static class NullableParseHelper
    {
        public delegate bool TP<T>(string a, out T ou);
        internal static K? ParseNullable<K>(string a, TP<K> tp) where K : struct
        {
            K retval = default;
            return retval;
        }
        internal static K? ParseNullable<K>(this K source, string a, TP<K> tp) where K : struct
        {
            K retv = default;
            if (tp(a, out retv))
                return retv;
            else
                return null;
        }
        public static decimal? ParseNullable(this decimal source, string a)
        {
            return source.ParseNullable(a, decimal.TryParse);
        }
        public static int? ParseNullable(this int source, string a)
        {
            return source.ParseNullable(a, int.TryParse);
        }
        public static long? ParseNullable(this long source, string a)
        {
            return source.ParseNullable(a, long.TryParse);
        }
        public static double? ParseNullable(this double source, string a)
        {
            return source.ParseNullable(a, double.TryParse);
        }
        public static DateTime? ParseNullable(this DateTime source, string a)
        {
            return source.ParseNullable(a, DateTime.TryParse);
        }
    }
}
