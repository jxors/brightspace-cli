using CommandLine;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace BrightspaceCli.Verbs
{
    [Verb("interactive")]
    public class Interactive : BaseVerb
    {
        public override Task ExecuteAsync(Context context, TextWriter writer)
        {
            while (true)
            {
                writer.Write($"[brightspace-cli]: ");
                var line = Console.ReadLine();
                if (line == "exit")
                {
                    break;
                }

                var args = Parse(line);
                Program.ExecuteCommand(args, context);

                writer.WriteLine();
            }

            return Task.CompletedTask;
        }

        private static string[] Parse(string str)
        {
            if (string.IsNullOrWhiteSpace(str))
            {
                return new string[0];
            }

            var index = str.Trim().IndexOf(" ", StringComparison.Ordinal);
            if (index == -1)
            {
                return new[] { str };
            }

            var count = str.Length;
            var list = new List<string>();

            while (count > 0)
            {
                if (str[0] == '"')
                {
                    var temp = str.IndexOf("\"", 1, str.Length - 1, StringComparison.Ordinal);
                    while (str[temp - 1] == '\\')
                    {
                        temp = str.IndexOf("\"", temp + 1, str.Length - temp - 1, StringComparison.Ordinal);
                    }

                    index = temp + 1;
                }
                else if (str[0] == '\'')
                {
                    var temp = str.IndexOf("\'", 1, str.Length - 1, StringComparison.Ordinal);
                    while (str[temp - 1] == '\\')
                    {
                        temp = str.IndexOf("\'", temp + 1, str.Length - temp - 1, StringComparison.Ordinal);
                    }

                    index = temp + 1;
                }

                var s = str.Substring(0, index);
                var left = count - index;

                str = str.Substring(index, left).Trim();
                list.Add(s.Trim('"'));
                count = str.Length;
                index = str.IndexOf(" ", StringComparison.Ordinal);

                if (index == -1)
                {
                    var add = str.Trim('"', ' ');
                    if (add.Length > 0)
                    {
                        list.Add(add);
                    }

                    break;
                }
            }

            return list.ToArray();
        }
    }
}
