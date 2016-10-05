using FluentWebRequester.WebRequester.Impl.Data;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace FluentWebRequester.WebRequester.Impl
{
    public class PostJson : BaseWebRequest, IWebRequest
    {
        public HttpStatusCode CheckStatus(string url, Parameters<string, string> parameters = null, Authentication authToken = null)
        {
            throw new NotImplementedException();
        }

        public string GetContent(string url, Parameters<string, string> parameters = null, Authentication authToken = null)
        {
            throw new NotImplementedException();
        }

        public T Send<T>(string url, Parameters<string, string> parameters = null, Authentication authToken = null)
        {
            var http = (HttpWebRequest)WebRequest.Create(new Uri(url));
            http.Accept = ContentType.ApplicationJson;
            http.ContentType = ContentType.ApplicationJson;
            http.Method = "POST";

            if (authToken != null)
                http.Headers.Add(HttpRequestHeader.Authorization, authToken.GetAuthorizationToken());

            var json = parameters.GetJson();

            ASCIIEncoding encoding = new ASCIIEncoding();
            Byte[] bytes = encoding.GetBytes(json);

            using (Stream newStream = http.GetRequestStream())
            {
                newStream.Write(bytes, 0, bytes.Length);
                newStream.Close();
            }

            var response = http.GetResponse();

            var stream = response.GetResponseStream();
            var result = string.Empty;
            using (var sr = new StreamReader(stream))
            {
                result = sr.ReadToEnd();
            }
            response.Close();
            stream.Close();

            return JsonConvert.DeserializeObject<T>(result);
        }
    }
}
