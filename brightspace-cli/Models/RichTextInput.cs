namespace BrightspaceCli.Models
{
    public class RichTextInput
    {
        public string Content { get; set; } = "";

        /// <summary>
        /// Must be "Text" or "Html"
        /// </summary>
        public string Type { get; set; } = "Text";
    }
}
