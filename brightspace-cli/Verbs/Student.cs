using BrightspaceCli.Requests;
using CommandLine;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace BrightspaceCli.Verbs
{
    [Verb("student")]
    public class Student : BaseCourseVerb
    {
        [Value(1, HelpText = "the student's username")]
        public string Username { get; set; }

        [Option("id-only", Default = false)]
        public bool IdOnly { get; set; }

        public override async Task ExecuteAsync(Context context, TextWriter writer)
        {
            var user = await CourseEndpoint.FindUserByUsername(context, CourseId, Username);

            if (user == null)
            {
                writer.WriteLine("User not found.");
            }
            else if (IdOnly)
            {
                writer.WriteLine(user.Identifier);
            }
            else
            {
                writer.WriteLine(user);
            }
        }
    }
}
