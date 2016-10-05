using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentWebRequester.WebRequester
{
    public abstract class BaseWebRequest
    {
        protected const string Authorization = "Authorization";
        
        protected static class ContentType
        {
            public static string ApplicationJson
            {
                get { return "application/json"; }
            }

            public static string TextPlain
            {
                get { return "text/plain"; }
            }

            public static string ApplicationXFormUrlEncoded
            {
                get { return "application/x-www-form-urlencoded"; }
            }
        }

    }
}
