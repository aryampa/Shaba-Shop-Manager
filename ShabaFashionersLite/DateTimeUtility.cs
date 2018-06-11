using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShabaFashionersLite
{
    class DateTimeUtility
    {
        

        public String ToEpochFormat(DateTime NormalDate) { 

            DateTime startTimes = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            return  Convert.ToInt64((NormalDate.ToUniversalTime() - startTimes).TotalSeconds).ToString();
            

        }

        public String FromEpochFormat(long EpochDate){

             double millssss = EpochDate;

             DateTime startTimes = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

             TimeSpan timedd = TimeSpan.FromSeconds(millssss);

             return  startTimes.AddSeconds(millssss).ToLocalTime().ToString(); 

        }
    }
}
