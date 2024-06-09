using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudBlazor.Core.Extensions
{
    public static class DateTimeExtensions
    {
        public static string DateToString(this DateTime? dt)
        {
            if (dt.HasValue)
                return dt.Value.ToString("yyyy-MM-dd");
            else 
                return string.Empty; 
        }

        public static DateTime? StringToDate(this string? s)
        {
            if(!string.IsNullOrEmpty(s) && s.Length == 10)
                return Convert.ToDateTime(s);
            else 
                return null; 
        }
    }
}
