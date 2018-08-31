namespace BrightspaceCli.Models.Grades
{
    public class SelectBoxIncomingGradeValue : IncomingGradeValue
    {
        public override int GradeObjectType => 3;

        public string Value { get; set; }
    }
}
