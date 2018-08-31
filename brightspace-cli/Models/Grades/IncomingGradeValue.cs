namespace BrightspaceCli.Models.Grades
{
    public abstract class IncomingGradeValue
    {
        public RichTextInput Comments { get; set; } = new RichTextInput();

        public RichTextInput PrivateComments { get; set; } = new RichTextInput();

        public abstract int GradeObjectType { get; } 
    }
}
