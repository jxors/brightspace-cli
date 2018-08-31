namespace BrightspaceCli.Models.Enrollment
{
    public class ClasslistUser
    {
        public string Identifier { get; set; }

        public string ProfileIdentifier { get; set; }

        public string DisplayName { get; set; }

        public string Username { get; set; }

        public string OrgDefinedId { get; set; }

        public string Email { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public override string ToString()
        {
            return $"{LastName}, {FirstName} ({Identifier}, {Username})";
        }
    }
}
