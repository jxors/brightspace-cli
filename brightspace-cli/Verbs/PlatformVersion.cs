using BrightspaceCli.Requests;
using CommandLine;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace BrightspaceCli.Verbs
{
    [Verb("platform-version")]
    public class PlatformVersion : BaseVerb
    {
        [Option('p', "products")]
        public string Products { get; set; } = "lp,le";

        public override async Task ExecuteAsync(Context context, TextWriter writer)
        {
            foreach(var product in Products.Split(","))
            {
                writer.WriteLine(await VersionEndpoint.GetSupportedVersions(context, product));
            }
        }
    }
}
