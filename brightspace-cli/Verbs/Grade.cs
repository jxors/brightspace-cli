using BrightspaceCli.Models;
using BrightspaceCli.Models.Grades;
using BrightspaceCli.Requests;
using CommandLine;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace BrightspaceCli.Verbs
{
    [Verb("grade")]
    public class Grade : BaseCourseGradeObjVerb
    {
        [Value(2, HelpText = "user ID")]
        public int UserId { get; set; }

        public override async Task ExecuteAsync(Context context, TextWriter writer)
        {
            var currentGrade = await GradeEndpoint.GetValue(context, CourseId, GradeObjectId, UserId);

            if (currentGrade == null)
            {
                writer.WriteLine("No grade available");
            }
            else
            {
                writer.WriteLine($"Displayed: {currentGrade.DisplayedGrade}");
                writer.WriteLine($"Points: {currentGrade.PointsNumerator} / {currentGrade.PointsDenominator}");
            }
        }
    }
}
