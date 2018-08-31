using System;
using System.Collections.Generic;
using System.Text;

namespace BrightspaceCli.Models.Grades
{
    public class GradeUser
    {
        public string Identifier { get; set; }

        public string ProfileIdentifier { get; set; }

        public string DisplayName { get; set; }

        public string Username { get; set; }

        public string OrgDefinedId { get; set; }

        public string EmailAddress { get; set; }

        public override string ToString()
        {
            return $"{Username} ({Identifier})";
        }
    }
}
