using BrightspaceCli.Models;
using D2L.Extensibility.AuthSdk;
using D2L.Extensibility.AuthSdk.Restsharp;
using RestSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace BrightspaceCli
{
    public class Context
    {
        public ID2LAppContext ValenceAppContext { get; }

        public HostSpec ValenceHost { get; }
        public RestClient Client { get; }
        public ID2LUserContext ValenceUserContext { get; set; }

        public Context(Configuration config)
        {
            var appFactory = new D2LAppContextFactory();
            ValenceAppContext = appFactory.Create(config["appId"], config["appKey"]);
            ValenceHost = new HostSpec("https", config["lmsUrl"], 443);
            Client = new RestClient("https://" + config["lmsUrl"]);

            if (File.Exists(".bs-auth"))
            {
                ValenceUserContext = ValenceAppContext.CreateUserContext(new Uri(File.ReadAllText(".bs-auth")), ValenceHost);
            }
            else
            {
                ValenceUserContext = null;
            }
        }

        public async Task Put<T>(string route, T data)
        {
            var authenticator = new ValenceAuthenticator(ValenceUserContext);
            var request = new RestRequest(route)
            {
                RequestFormat = DataFormat.Json,
                Method = Method.PUT,
            };

            request.AddBody(data);

            authenticator.Authenticate(Client, request);

            await Client.ExecuteTaskAsync<T>(request);
        }

        public async Task<T> Request<T>(string route) where T : new()
        {
            var authenticator = new ValenceAuthenticator(ValenceUserContext);
            var request = new RestRequest(route);

            authenticator.Authenticate(Client, request);

            var response = await Client.ExecuteTaskAsync<T>(request);

            return response.Data;
        }

        public async Task SetAuthenticationData(Uri url)
        {
            await File.WriteAllTextAsync(".bs-auth", url.ToString());
        }

        public Uri GetAuthenticationUri()
        {
            return ValenceAppContext.CreateUrlForAuthentication(ValenceHost, new Uri("http://pulse.brightspace.com/android/trustedURL"));
        }
    }
}
