using CommandLine;

namespace BrightspaceCli.Verbs
{
    public abstract class BaseCourseGradeObjVerb : BaseCourseVerb
    {
        [Value(1, HelpText = "grade object ID")]
        public int GradeObjectId { get; set; }
    }
}
