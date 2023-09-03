using FakerCLI;

public class GeneratorTests
{
    [Fact]
    public void Generate_WhenHasCpfOption_GeneratesCpfData()
    {
        var arg = new Arg(new string[] { Arg.CpfOption });
        var generator = new Generator(arg);

        generator.Generate();

        Assert.All(generator.FakerData, data =>
        {
            Assert.Matches(@"\d{11}", data);
        });
    }

    [Fact]
    public void Generate_WhenHasCpfOption_AndHasFormated_GeneratesCpfData()
    {
        var arg = new Arg(new string[] { Arg.CpfOption, Arg.FormatedOption });
        var generator = new Generator(arg);

        generator.Generate();

        Assert.All(generator.FakerData, data =>
        {
            Assert.Matches(@"^\d{3}\.\d{3}\.\d{3}\-\d{2}", data);
        });
    }

    [Fact]
    public void Generate_WhenHasCnpjOption_GeneratesCnpjData()
    {
        var arg = new Arg(new string[] { Arg.CnpjOption });
        var generator = new Generator(arg);

        generator.Generate();

        Assert.All(generator.FakerData, data =>
        {
            Assert.Matches(@"\d{14}", data);
        });
    }

    [Fact]
    public void Generate_WhenHasCnpjOption_AndHasFormated_GeneratesCnpjData()
    {
        var arg = new Arg(new string[] { Arg.CnpjOption, Arg.FormatedOption });
        var generator = new Generator(arg);

        generator.Generate();

        Assert.All(generator.FakerData, data =>
        {
            Assert.Matches(@"^\d{2}\.\d{3}\.\d{3}\/\d{4}\-\d{2}$", data);
        });
    }

    [Fact]
    public void Generate_WhenHasEmailOption_GeneratesEmailData()
    {
        var arg = new Arg(new string[] { Arg.EmailOptions });
        var generator = new Generator(arg);

        generator.Generate();

        Assert.All(generator.FakerData, data =>
        {
            Assert.Matches(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$", data);
        });
    }

    [Fact]
    public void Generate_WhenHasPhoneOption_GeneratesPhoneData()
    {
        var arg = new Arg(new string[] { Arg.PhoneOptions });
        var generator = new Generator(arg);

        generator.Generate();

        Assert.All(generator.FakerData, data =>
        {
            Assert.Matches(@"\d{11}", data);
        });
    }

    [Fact]
    public void Generate_WhenHasPhoneOption_AndHasFormated_GeneratesPhoneData()
    {
        var arg = new Arg(new string[] { Arg.PhoneOptions, Arg.FormatedOption });
        var generator = new Generator(arg);

        generator.Generate();

        Assert.All(generator.FakerData, data =>
        {
            Assert.Matches(@"\(\d{2}\) \d{1}\.\d{4}-\d{4}", data);
        });
    }

    [Fact]
    public void Generate_WhenHasZipCodeOption_GeneratesZipCodeData()
    {
        var arg = new Arg(new string[] { Arg.ZipCodeOptions });
        var generator = new Generator(arg);

        generator.Generate();

        Assert.All(generator.FakerData, data =>
        {
            Assert.Matches(@"\d{8}", data);
        });
    }

    [Fact]
    public void Generate_WhenHasZipCodeOption_AndHasFormated_GeneratesFormatedZipCodeData()
    {
        var arg = new Arg(new string[] { Arg.ZipCodeOptions, Arg.FormatedOption });
        var generator = new Generator(arg);

        generator.Generate();

        Assert.All(generator.FakerData, data =>
        {
            Assert.Matches(@"\d{2}\.\d{3}-\d{3}", data);
        });
    }
}