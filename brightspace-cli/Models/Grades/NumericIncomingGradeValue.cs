namespace BrightspaceCli.Models.Grades
{
    public class NumericIncomingGradeValue : IncomingGradeValue
    {
        public override int GradeObjectType => 1;

        public decimal PointsNumerator { get; set; }
    }
}
