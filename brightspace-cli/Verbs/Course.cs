using BrightspaceCli.Requests;
using CommandLine;
using System.IO;
using System.Threading.Tasks;

namespace BrightspaceCli.Verbs
{
    [Verb("course")]
    public class Course : BaseCourseVerb
    {
        public override async Task ExecuteAsync(Context context, TextWriter writer)
        {
            var gradeObjs = await GradeEndpoint.GetAllForCourse(context, CourseId);

            writer.WriteLine("Grades:");
            foreach(var gradeObj in gradeObjs)
            {
                writer.WriteLine($"* {gradeObj.Name} ({gradeObj.Id})");
            }
        }
    }
}
