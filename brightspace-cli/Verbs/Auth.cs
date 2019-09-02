using CommandLine;
using System;
using System.IO;
using System.Threading.Tasks;

namespace BrightspaceCli.Verbs
{
    [Verb("auth")]
    public class Auth : BaseVerb
    {
        [Option("url", Required = false)]
        public string Url { get; set; } = null;

        public override async Task ExecuteAsync(Context context, TextWriter writer)
        {
            if (!string.IsNullOrWhiteSpace(Url))
            {
                await context.SetAuthenticationData(new Uri(Url));
                await writer.WriteLineAsync("Authentication data saved");
            }
            else
            {
                await writer.WriteLineAsync($"Fetching authentication URL...");
                var authUrl = context.GetAuthenticationUri();

                await writer.WriteLineAsync($"Please authenticate on this URL: {authUrl}");
                await writer.WriteLineAsync();
                await writer.WriteLineAsync("You'll be redirected to a non-existant URL. Copy that URL and execute the following command:");
                await writer.WriteLineAsync("bs-hacks auth --url [PASTE THE URL HERE]");
            }
        }
    }
}
