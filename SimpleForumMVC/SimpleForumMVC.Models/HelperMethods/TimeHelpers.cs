using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleForumMVC.Models.HelperMethods
{
    public class TimeHelpers
    {
       public static string GetTimeDiff(DateTime timePost)
        {
            string result = string.Empty;
            DateTime timeNow = DateTime.Now;
            TimeSpan timeDiff = timeNow.Subtract(timePost);
            if (timeDiff.Days > 0)
            {
                return timeDiff.Days.ToString()+" days ago in";
            }

            if (timeDiff.Hours > 0)
            {
                return timeDiff.Hours.ToString() + " hours ago in";
            }

            if (timeDiff.Minutes > 0)
            {
                return timeDiff.Minutes.ToString() + " minutes ago in";
            }

            if (timeDiff.Seconds > 0)
            {
                return timeDiff.Seconds.ToString() + " seconds ago in";
            }

            return result;
        }
    }
}
