using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bier
{
    public static class ApplicationDumbCache
    {


        public static DumbCache DumbCache
        {
            get
            {
                return HttpContext.Current.Application["DumbCache"] as DumbCache;
            }
            set
            {
                HttpContext.Current.Application["DumbCache"] = value;
            }
        }
    }
}