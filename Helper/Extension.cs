using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Beam.Helper
{
    public static class Extension
    {
        const string format = "ddd MMM dd HH:mm:ss zzzz yyyy";

        public static string ParseDatetime(this string date)
        {
            return DateTime.ParseExact(date, format, CultureInfo.InvariantCulture).ToString("yyyy년 MM월 dd일 hh:mm:ss");
        }

        public static string ParseClientSource(this string source)
        {
            Regex r = new Regex("<a.*>(.*)</a>");
            Match m = r.Match(source);
            return m.Groups[1].ToString();

        }
    }
}
