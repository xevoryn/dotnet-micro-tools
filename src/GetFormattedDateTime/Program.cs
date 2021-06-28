using System;
using System.Linq;

var useUtc = false;
var format = @"yyyyMMddHHmmss";

var skipNextLoop = false;
for (int i = 0; i < args.Length; i++)
{
    if (skipNextLoop)
    {
        skipNextLoop = false;
        continue;
    }
    
    switch (args[i])
    {
        case "-utc":
            useUtc = true;
            break;
        case "-format":
            format = args[i + 1];
            skipNextLoop = true;
            break;
        default:
            Console.Out.WriteLine($"Usage: getformatteddatetime [options]");
            Console.Out.WriteLine();
            Console.Out.WriteLine("### options ###");
            Console.Out.WriteLine($"{new string(' ', 4)}-utc{new string(' ', 27)}Uses UTC instead of local DateTime if argument is present");
            Console.Out.WriteLine($"{new string(' ', 4)}-format <format-string>{new string(' ', 8)}Uses the passed format string to format the resulting DateTime");
            return 0;
    }
}

if (useUtc)
    Console.Out.WriteLine(DateTime.UtcNow.ToString(format));
else
    Console.Out.WriteLine(DateTime.Now.ToString(format));

return 0;
