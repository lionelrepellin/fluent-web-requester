﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentWebRequester.WebRequester.Impl.Data
{
    public class Authentication
    {
        public string AccessToken { get; set; }
        public string TokenType { get; set; }
        public int ExpiresIn { get; set; }

        public string GetAuthorizationToken()
        {
            return string.Format("{0} {1}", TokenType, AccessToken);
        }
    }
}
