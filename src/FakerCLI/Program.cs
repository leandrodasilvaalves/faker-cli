using FakerCLI;

var _args = new Arg(args);
var generator = new Generator(_args);

generator.Generate();
foreach(var data in generator.FakerData)
{
    Console.WriteLine(data);
}