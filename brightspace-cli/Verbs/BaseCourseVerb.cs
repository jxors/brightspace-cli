using CommandLine;

namespace BrightspaceCli.Verbs
{
    public abstract class BaseCourseVerb : BaseVerb
    {
        [Value(0, HelpText = "the course ID")]
        public int CourseId { get; set; }
    }
}
