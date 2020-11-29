using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EShop.API.Extentions
{
    public static class TimeFilter
    {
        public static DateTime GetTime(this DateTime d)
        {
            return new DateTime(d.TimeOfDay.Ticks, d.Kind);
        }
    }
}