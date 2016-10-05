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
    public class PostCsv : BaseWebRequest, IWebRequest
    {
        public HttpStatusCode CheckStatus(string url, Parameters<string, string> parameters = null, Authentication authToken = null)
        {
            using (var webClient = new WebClient())
            {
                webClient.Headers.Add("Content-Type", ContentType.TextPlain);

                if (authToken != null)
                    webClient.Headers.Add(Authorization, authToken.GetAuthorizationToken());

                var uri = new Uri(url);
                var statusCode = HttpStatusCode.OK;

                try
                {
                    var result = webClient.UploadString(uri, parameters.GetCsv());
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
                webClient.Headers.Add("Content-Type", ContentType.TextPlain);

                if (authToken != null)
                    webClient.Headers.Add(Authorization, authToken.GetAuthorizationToken());

                var uri = new Uri(url);
                var result = webClient.UploadString(uri, parameters.GetCsv());

                return JsonConvert.DeserializeObject<T>(result);
            }
        }
    }
}
