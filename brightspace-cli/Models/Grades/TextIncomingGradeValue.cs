namespace BrightspaceCli.Models.Grades
{
    public class TextIncomingGradeValue : IncomingGradeValue
    {
        public override int GradeObjectType => 4;

        public string Text { get; set; }
    }
}
