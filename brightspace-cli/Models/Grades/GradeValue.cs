namespace BrightspaceCli.Models.Grades
{
    public class GradeValue
    {
        public long UserId { get; set; }

        public long OrgUnitId { get; set; }

        public string DisplayedGrade { get; set; }

        public string GradeObjectIdentifier { get; set; }

        public GradeObjT GradeObjectType { get; set; }

        public string GradeObjectTypeName { get; set; }

        public RichText Comments { get; set; }

        public RichText PrivateComments { get; set; }

        // Only for computable objects
        public int? PointsNumerator { get; set; }
        public int? PointsDenominator { get; set; }
        public int? WeightedDenominator { get; set; }
        public int? WeightedNumerator { get; set; }
    }
}