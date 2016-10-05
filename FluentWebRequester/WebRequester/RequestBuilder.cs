using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using FluentWebRequester.WebRequester.Impl;
using FluentWebRequester.WebRequester.Impl.Data;

namespace FluentWebRequester.WebRequester
{
    public class RequestBuilder
    {
        private IWebRequest _webRequest;
        private string _url;
        private Parameters<string, string> _parameters;
        private Authentication _token;

        #region Creation methods

        public static RequestBuilder Post()
        {
            var webRequest = new Post();
            return new RequestBuilder { _webRequest = webRequest };
        }

        public static RequestBuilder Get()
        {
            var webRequest = new Get();
            return new RequestBuilder { _webRequest = webRequest };
        }

        public static RequestBuilder Delete()
        {
            var webRequest = new Delete();
            return new RequestBuilder { _webRequest = webRequest };
        }

        public static RequestBuilder PostJson()
        {
            var webRequest = new PostJson();
            return new RequestBuilder { _webRequest = webRequest };
        }

        public static RequestBuilder PostCsv()
        {
            var webRequest = new PostCsv();
            return new RequestBuilder { _webRequest = webRequest };
        }

        #endregion

        public RequestBuilder AddUrl(string url)
        {
            _url = url;
            return this;
        }

        public RequestBuilder AddAuthToken(Authentication token)
        {
            _token = token;
            return this;
        }

        public RequestBuilder AddParameters(string key, string value)
        {
            if (_parameters == null)
                _parameters = new Parameters<string, string>();

            _parameters.Add(key, value);
            return this;
        }

        #region Action methods

        public T Send<T>()
        {
            return _webRequest.Send<T>(_url, _parameters, _token);
        }

        public HttpStatusCode CheckStatus()
        {
            return _webRequest.CheckStatus(_url, _parameters, _token);
        }

        public string GetContent()
        {
            return _webRequest.GetContent(_url, _parameters, _token);
        }

        #endregion
    }
}
