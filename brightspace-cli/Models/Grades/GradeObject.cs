namespace BrightspaceCli.Models.Grades
{
    public class GradeObject
    {
        public decimal MaxPoints { get; set; }

        public bool CanExceedMaxPoints { get; set; }

        public bool IsBonus { get; set; }

        public bool ExcludeFromFinalGradeCalculation { get; set; }

        public int? GradeSchemeId { get; set; }

        public long Id { get; set; }

        public string Name { get; set; }

        public string ShortName { get; set; }

        public string GradeType { get; set; }

        public long? CategoryId { get; set; }

        public RichText Description { get; set; }

        public string GradeschemeUrl { get; set; }

        public decimal Weight { get; set; }

        public long? ActivityId { get; set; }

        public AssociatedTool AssociatedTool { get; set; }
    }
}
