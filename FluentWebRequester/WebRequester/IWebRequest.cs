using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using FluentWebRequester.WebRequester.Impl.Data;

namespace FluentWebRequester.WebRequester
{
    public interface IWebRequest
    {
        T Send<T>(string url, Parameters<string, string> parameters = null, Authentication authToken = null);
        string GetContent(string url, Parameters<string, string> parameters = null, Authentication authToken = null);
        HttpStatusCode CheckStatus(string url, Parameters<string, string> parameters = null, Authentication authToken = null);
    }
}
