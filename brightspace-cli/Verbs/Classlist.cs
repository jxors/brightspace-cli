using BrightspaceCli.Requests;
using CommandLine;
using System.IO;
using System.Threading.Tasks;

namespace BrightspaceCli.Verbs
{
    [Verb("classlist")]
    public class Classlist : BaseCourseVerb
    {
        public override async Task ExecuteAsync(Context context, TextWriter writer)
        {
            var classlist = await CourseEndpoint.GetClasslist(context, CourseId);

            foreach (var user in classlist)
            {
                writer.WriteLine(user);
            }
        }
    }
}
