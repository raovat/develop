using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace LibCore.Helper.Uri
{
    public static class UriHelper
    {
        public static bool IsHashURL()
        {
            return HttpContext.Current.Request.QueryString["hashtable"] == "true";
        }
    }
}
