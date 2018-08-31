namespace BrightspaceCli.Models
{
    public class RichText
    {
        public string Text { get; set; }

        public string Html { get; set; }

        public override string ToString()
        {
            return Html ?? Text;
        }
    }
}
