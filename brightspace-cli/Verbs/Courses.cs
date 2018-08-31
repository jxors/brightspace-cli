using BrightspaceCli.Requests;
using CommandLine;
using System.IO;
using System.Threading.Tasks;

namespace BrightspaceCli.Verbs
{
    [Verb("courses")]
    public class Courses : BaseVerb
    {
        public override async Task ExecuteAsync(Context context, TextWriter writer)
        {
            var result = await CourseEndpoint.GetAll(context);
            foreach(var item in result.Items)
            {
                foreach (var orgUnit in item.OrgUnit)
                {
                    writer.WriteLine($"* [{orgUnit.Type.Name}] {orgUnit.Code} ({orgUnit.Id}) - {orgUnit.Name}");
                }
            }
        }
    }
}
