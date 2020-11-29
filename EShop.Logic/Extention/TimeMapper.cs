using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShop.Logic.Extention
{
    public static class TimeMapper
    {

        public static DateTime GetTime(this DateTime d)
        {
            return new DateTime(d.TimeOfDay.Ticks, d.Kind);
        }
    }
}
