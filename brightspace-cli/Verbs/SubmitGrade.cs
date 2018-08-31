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
    [Verb("submit-grade")]
    public class SubmitGrade : BaseCourseGradeObjVerb
    {
        [Value(2, HelpText = "user ID")]
        public int UserId { get; set; }

        [Option("value", Required = true)]
        public string Value { get; set; }

        [Option("grade-type", Required = false, Default = null)]
        public GradeObjT? GradeType { get; set; }

        [Option('c', "comment", Required = false, Default = null)]
        public string Comments { get; set; }

        [Option('p', "private-comment", Required = false, Default = null)]
        public string PrivateComments { get; set; }

        public override async Task ExecuteAsync(Context context, TextWriter writer)
        {
            var incomingGrade = await CreateIncomingGrade(context);
            if (Comments != null)
            {
                incomingGrade.Comments = CreateComments(Comments);
            }

            if (PrivateComments != null)
            {
                incomingGrade.PrivateComments = CreateComments(PrivateComments);
            }

            await GradeEndpoint.UpdateGrade(context, CourseId, GradeObjectId, UserId, incomingGrade);
            writer.WriteLine("Grade updated.");
        }

        private RichTextInput CreateComments(string text)
        {
            return new RichTextInput
            {
                Content = text,
                Type = "Text",
            };
        }

        private async Task<GradeObjT> GetGradeType(Context context)
        {
            if (GradeType == null)
            {
                var gradeObj = await GradeEndpoint.Get(context, CourseId, GradeObjectId);
                return Enum.Parse<GradeObjT>(gradeObj.GradeType, true);
            }

            return GradeType.Value;
        }

        private static bool ConvertToBool(string text)
        {
            var mapping = new[]
            {
                ("true", true),
                ("false", false),
                ("pass", true),
                ("fail", false),
                ("0", false),
                ("1", true),
            };

            foreach(var map in mapping)
            {
                if (string.Equals(text, map.Item1, StringComparison.InvariantCultureIgnoreCase))
                {
                    return map.Item2;
                }
            }

            throw new InvalidCastException($"Cannot convert {text} to a fail/pass value.");
        }

        private async Task<IncomingGradeValue> CreateIncomingGrade(Context context)
        {
            var type = await GetGradeType(context);
            switch(type)
            {
                case GradeObjT.Numeric:
                    return new NumericIncomingGradeValue
                    {
                        PointsNumerator = decimal.Parse(Value),
                    };
                case GradeObjT.PassFail:
                    return new PassFailIncomingGradeValue
                    {
                        Pass = ConvertToBool(Value),
                    };
                case GradeObjT.SelectBox:
                    return new SelectBoxIncomingGradeValue
                    {
                        Value = Value,
                    };
                case GradeObjT.Text:
                    return new TextIncomingGradeValue
                    {
                        Text = Value,
                    };
                default: throw new NotSupportedException();
            }
        }
    }
}
