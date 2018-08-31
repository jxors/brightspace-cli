using BrightspaceCli.Verbs;
using CommandLine;
using System;
using System.Linq;

namespace BrightspaceCli
{
    class Program
    {
        static int Main(string[] args)
        {
            var context = new Context(new Configuration());
            return ExecuteCommand(args, context);
        }

        public static int ExecuteCommand(string[] args, Context context)
        {
            var result = Parser.Default.ParseArguments(args, typeof(Program)
                .Module
                .GetTypes()
                .Where(type => type.GetCustomAttributes(true).OfType<VerbAttribute>().Any())
                .ToArray()
            );

            var returnCode = 0;
            result.WithParsed((options) =>
            {
                try
                {
                    var verb = (BaseVerb)options;
                    verb.ExecuteAsync(context, Console.Out).GetAwaiter().GetResult();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    returnCode = -1;
                }
            });

            return returnCode;
        }
    }
}
