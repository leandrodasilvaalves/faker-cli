using FakerCLI;

var arg = new Arg(args);

if (arg.ShouldShowHelp())
{
    arg.ShowHelp();
    return;
}

var generator = new Generator(arg);

generator.Generate();
foreach(var data in generator.FakerData)
{
    Console.WriteLine(data);
}