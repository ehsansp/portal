using System;
using System.Collections.Generic;
using System.Text;
using RestSharp;
using RestSharp.Authenticators;

namespace ShahrKoodak.Core.common
{
    public class BaseClientAuthenticator : IAuthenticator
    {
        private readonly string _apiKey;

        public BaseClientAuthenticator(string apiKey)
        {
            _apiKey = apiKey;
        }

        public void Authenticate(IRestClient client, IRestRequest request)
        {
            request.AddHeader("x-api-key", _apiKey);
        }
    }
}
