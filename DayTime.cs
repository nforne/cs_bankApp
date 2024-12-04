using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Week12_Lab01_BankApp
{
    internal struct DayTime
    {
            /*
                • 1 hour = 60 minutes
                • 1 day = 24 hours = 24 * 60 = 1_440 minutes
                • 1 month = 30 days = 30 * 1_440 = 43_200 minutes
                • 1 year = 12 months = 12 * 43_200 = 518_400 minutes
                • Time starts on the zero minute of the zero hour of the first day of the first month of the
                  zero year. i.e. 0 minute will be 2023–01–01 00:00
             */
        private long minutes;
        public DayTime(long mins) {
            this.minutes = mins;
        }

        public static DayTime operator +(DayTime lhs, int minute){
            lhs.minutes += minute; // This is used in the Util class to get the current time(Utils.Now) and incremented time(Utils.Time)
            return lhs; 
        }

        public override string ToString() {
            long yr = 0;
            long mo = 0;
            long dy = 0;
            long hr = 0;
            long mi = 0;

            long checker = this.minutes;
            if (checker >= 518_400)
            {
                yr = ((minutes - (minutes % 518_400)) / 518_400) + 2023;
                checker = minutes % 518_400;
            }
            else { yr = 2023; }
            if (checker >= 43_200)
            {
                mo = ((checker - (checker % 43_200)) / 43_200);
                checker = checker % 43_200;
            }
            else { mo = 1; }
            if (checker >= 1_440)
            {
                dy = ((checker - (checker % 1_440)) / 1_440) + 0;
                checker = checker % 1_440;
            }
            else { dy = 1; }
            if (checker >= 60)
            {
                hr = ((checker - (checker % 60)) / 60) + 0;
                checker = checker % 60;
            }
            else { hr = 00; }
            mi = checker;


            return $"{yr}-{mo}-{dy} {hr}:{mi}";
        }
    }
}
