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
    public class Post : BaseWebRequest, IWebRequest
    {
        public HttpStatusCode CheckStatus(string url, Parameters<string, string> parameters = null, Authentication authToken = null)
        {
            using (var webClient = new WebClient())
            {
                webClient.Headers.Add("Content-Type", ContentType.ApplicationXFormUrlEncoded);

                if (authToken != null)
                    webClient.Headers.Add(Authorization, authToken.GetAuthorizationToken());

                var statusCode = HttpStatusCode.OK;
                var uri = new Uri(url);

                try
                {
                    var result = webClient.UploadString(uri, parameters?.GetQueryString() ?? string.Empty);
                }
                catch (WebException exception)
                {
                    statusCode = (exception.Response as HttpWebResponse).StatusCode;
                }

                return statusCode;
            }
        }

        public string GetContent(string url, Parameters<string, string> parameters = null, Authentication authToken = null)
        {
            throw new NotImplementedException();
        }

        public T Send<T>(string url, Parameters<string, string> parameters = null, Authentication authToken = null)
        {
            using (var webClient = new WebClient())
            {
                webClient.Headers.Add("Content-Type", ContentType.ApplicationXFormUrlEncoded);

                if (authToken != null)
                    webClient.Headers.Add(Authorization, authToken.GetAuthorizationToken());

                var uri = new Uri(url);
                var result = webClient.UploadString(uri, parameters?.GetQueryString());

                return JsonConvert.DeserializeObject<T>(result);
            }
        }
    }
}
