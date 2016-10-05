using FluentWebRequester.WebRequester.Impl.Data;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace FluentWebRequester.WebRequester.Impl
{
    public class Get : BaseWebRequest, IWebRequest
    {
        public HttpStatusCode CheckStatus(string url, Parameters<string, string> parameters = null, Authentication authToken = null)
        {
            var statusCode = HttpStatusCode.OK;

            using (var webClient = new WebClient())
            {
                if (authToken != null)
                    webClient.Headers.Add(Authorization, authToken.GetAuthorizationToken());

                var uri = CreateUri(url, parameters);

                try
                {
                    var result = webClient.DownloadString(uri);
                }
                catch (WebException exception)
                {
                    statusCode = (exception.Response as HttpWebResponse).StatusCode;
                }
            }

            return statusCode;
        }

        public string GetContent(string url, Parameters<string, string> parameters = null, Authentication authToken = null)
        {
            using (var webClient = new WebClient())
            {
                if (authToken != null)
                    webClient.Headers.Add(Authorization, authToken.GetAuthorizationToken());

                var uri = CreateUri(url, parameters);
                return webClient.DownloadString(uri);
            }
        }

        public T Send<T>(string url, Parameters<string, string> parameters = null, Authentication authToken = null)
        {
            using (var webClient = new WebClient())
            {
                if (authToken != null)
                    webClient.Headers.Add(Authorization, authToken.GetAuthorizationToken());

                var uri = CreateUri(url, parameters);
                var result = webClient.DownloadString(uri);

                return JsonConvert.DeserializeObject<T>(result);
            }
        }

        private Uri CreateUri(string url, Parameters<string, string> parameters = null)
        {
            var queryString = parameters?.GetQueryString() ?? string.Empty;

            if (!string.IsNullOrEmpty(queryString))
                return new Uri(string.Concat("{0}?{1}", url, queryString));

            return new Uri(url);
        }
    }
}
