using BrightspaceCli.ModelExtensions;
using BrightspaceCli.Requests;
using CommandLine;
using System.IO;
using System.Threading.Tasks;

namespace BrightspaceCli.Verbs
{
    [Verb("grades")]
    public class Grades : BaseCourseGradeObjVerb
    {
        public override async Task ExecuteAsync(Context context, TextWriter writer)
        {
            var page = await GradeEndpoint.GetValues(context, CourseId, GradeObjectId);
            var grades = await page.All(context);

            foreach(var grade in grades)
            {
                writer.WriteLine($"{grade.User}: {grade.GradeValue?.DisplayedGrade}");
            }
        }
    }
}
