using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentWebRequester.WebRequester.Impl.Data
{
    public class Parameters<TKey, TValue> : Dictionary<TKey, TValue>
    {
        private Dictionary<TKey, TValue> _dictionary;

        public Parameters() : base()
        {
            _dictionary = new Dictionary<TKey, TValue>();
        }

        public Parameters(int capacity) : base(capacity) { }

        public new void Add(TKey key, TValue value)
        {
            _dictionary.Add(key, value);
        }

        public string GetQueryString()
        {
            var keys = _dictionary.Keys;
            var queryString = string.Empty;
            foreach (var key in keys)
            {
                TValue value;
                _dictionary.TryGetValue(key, out value);
                queryString += string.Format("{0}={1}&", key, value);
            }

            return queryString.Substring(0, queryString.Length - 1);
        }

        public string GetCsv()
        {
            var keys = _dictionary.Keys;
            var csv = string.Empty;

            foreach (var key in keys)
            {
                TValue value;
                _dictionary.TryGetValue(key, out value);
                csv += string.Format("{0}", value) + Environment.NewLine;
            }

            return csv;
        }

        public string GetJson()
        {
            var keys = _dictionary.Keys;
            var json = string.Empty;
            foreach (var key in keys)
            {
                TValue value;
                _dictionary.TryGetValue(key, out value);
                json += string.Format("\"{0}\":\"{1}\",", key, value);
            }

            json = json.Substring(0, json.Length - 1);

            return string.Concat("[{", json, "}]");
        }
    }
}
