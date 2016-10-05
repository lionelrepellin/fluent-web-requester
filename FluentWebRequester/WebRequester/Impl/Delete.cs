using FluentWebRequester.WebRequester.Impl.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace FluentWebRequester.WebRequester.Impl
{
    public class Delete : BaseWebRequest, IWebRequest
    {
        public HttpStatusCode CheckStatus(string url, Parameters<string, string> parameters = null, Authentication authToken = null)
        {
            if (parameters != null)
                throw new NotImplementedException("parameters are not implemented");

            var uri = new Uri(url);
            var request = (HttpWebRequest)WebRequest.Create(uri);
            request.Method = "DELETE";
            request.ContentType = ContentType.ApplicationXFormUrlEncoded;
            
            if (authToken != null)
                request.Headers.Add(HttpRequestHeader.Authorization, authToken.GetAuthorizationToken());

            var statusCode = HttpStatusCode.OK;

            try
            {
                var response = request.GetResponse();
            }
            catch (WebException exception)
            {
                statusCode = (exception.Response as HttpWebResponse).StatusCode;
            }

            return statusCode;
        }

        public string GetContent(string url, Parameters<string, string> parameters = null, Authentication authToken = null)
        {
            throw new NotImplementedException();
        }

        public T Send<T>(string url, Parameters<string, string> parameters = null, Authentication authToken = null)
        {
            throw new NotImplementedException();
        }
    }
}
