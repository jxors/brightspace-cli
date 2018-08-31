namespace BrightspaceCli.Models
{
    public class WhoAmIUser
    {
        public string Identifier { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UniqueName { get; set; }
        public string ProfileIdentifier { get; set; }

        public override string ToString()
        {
            return $"{FirstName}{LastName} ({UniqueName}, {Identifier}, {ProfileIdentifier})";
        }
    }
}
