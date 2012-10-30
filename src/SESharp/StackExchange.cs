using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RestSharp;
using SESharp.JSON;
using SESharp.Auth;
using RestSharp.Authenticators;

namespace SESharp
{
    public partial class StackExchange
    {
        private const string apiRepo = "https://api.stackexchange.com";

        public RestClient client;

        public StackExchange()
        {
            client = new RestClient
            {
                BaseUrl = apiRepo
            };

            client.AddDefaultHeader("Accept", "application/vnd.github.beta+json");
        }

        public StackExchange(string username, string password) :
            this()
        {
            client.Authenticator = new Authenticator(username, password, false);
        }

        public StackExchange(string secrestPath) :
            this()
        {
            client.Authenticator = new Authenticator(secrestPath, false);
        }

        public Rate Limit
        {
            get
            {
                var request = new RestRequest
                    {
                        Resource = "/quota_remaining", 
                        Method = Method.GET,
                        RootElement = "rate"
                    };

                var response = client.Execute<Rate>(request);

                return response.Data;
            }
        }

        public Sites Sites
        {
            get
            {
                var request = new RestRequest
                {
                    Resource = "/2.1/sites",
                    Method = Method.GET
                };

                var response = client.Execute<Sites>(request);

                return response.Data;
            }
        }

        [Flags]
        public enum Scope
        {
            ReadInbox,
            NoExpiry,
            WriteAccess,
            PrivateInfo
        }

        public void Authorize(int clientId, Scope scope, string redirectUri, string state)
        {
            string baseUrl = "https://stackexchange.com";
            RestClient client = new RestClient(baseUrl);

            var request = new RestRequest
            {
                Resource = "/uath/{org}",
                Method = Method.GET
            };

            request.AddParameter("client_id", clientId, ParameterType.GetOrPost);
            request.AddParameter("scope", "read_inbox no_expiry private_info write_access", ParameterType.GetOrPost);
            request.AddParameter("redirect_uri ", redirectUri, ParameterType.GetOrPost);
            request.AddParameter("state ", state, ParameterType.GetOrPost);
        }
    }
}
