using BrightspaceCli.Requests;
using CommandLine;
using System.IO;
using System.Threading.Tasks;

namespace BrightspaceCli.Verbs
{
    [Verb("whoami")]
    public class WhoAmI : BaseVerb
    {
        public override async Task ExecuteAsync(Context context, TextWriter writer)
        {
            writer.WriteLine(await AuthStatusEndpoint.GetWhoAmIUser(context));
        }
    }
}
