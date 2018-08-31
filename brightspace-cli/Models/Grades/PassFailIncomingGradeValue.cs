namespace BrightspaceCli.Models.Grades
{
    public class PassFailIncomingGradeValue : IncomingGradeValue
    {
        public override int GradeObjectType => 2;

        public bool Pass { get; set; }
    }
}
