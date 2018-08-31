using System.IO;
using System.Threading.Tasks;

namespace BrightspaceCli.Verbs
{
    public abstract class BaseVerb
    {
        public abstract Task ExecuteAsync(Context context, TextWriter writer);
    }
}
