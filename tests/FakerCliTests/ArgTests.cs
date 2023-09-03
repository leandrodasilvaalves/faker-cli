using FakerCLI;

namespace FakerCliTests;

public class ArgTests
{
    [Fact]
    public void TestHasCpf_WhenOptionExists_ReturnsTrue()
    {
        var args = new string[] { Arg.CpfOption };
        var arg = new Arg(args);

        bool result = arg.HasCpf();

        Assert.True(result);
    }

    [Fact]
    public void TestHasCpf_WhenOptionDoesNotExist_ReturnsFalse()
    {
        var args = new string[] { Arg.CnpjOption, Arg.EmailOptions };
        var arg = new Arg(args);

        bool result = arg.HasCpf();

        Assert.False(result);
    }

    [Fact]
    public void TestHasCnpj_WhenOptionExists_ReturnsTrue()
    {
        var args = new string[] { Arg.CnpjOption };
        var arg = new Arg(args);

        bool result = arg.HasCnpj();

        Assert.True(result);
    }

    [Fact]
    public void TestHasCnpj_WhenOptionDoesNotExist_ReturnsFalse()
    {
        var args = new string[] { Arg.CpfOption, Arg.EmailOptions };
        var arg = new Arg(args);

        bool result = arg.HasCnpj();

        Assert.False(result);
    }

    [Fact]
    public void TestHasFormated_WhenOptionExists_ReturnsTrue()
    {
        var args = new string[] { Arg.FormatedOption };
        var arg = new Arg(args);

        bool result = arg.HasFormated();

        Assert.True(result);
    }

    [Fact]
    public void TestHasFormated_WhenOptionDoesNotExist_ReturnsFalse()
    {
        var args = new string[] { Arg.CpfOption, Arg.EmailOptions };
        var arg = new Arg(args);

        bool result = arg.HasFormated();

        Assert.False(result);
    }

    [Fact]
    public void TestHasEmail_WhenOptionExists_ReturnsTrue()
    {
        var args = new string[] { Arg.EmailOptions };
        var arg = new Arg(args);

        bool result = arg.HasEmail();

        Assert.True(result);
    }

    [Fact]
    public void TestHasEmail_WhenOptionDoesNotExist_ReturnsFalse()
    {
        var args = new string[] { Arg.CpfOption, Arg.CnpjOption };
        var arg = new Arg(args);

        bool result = arg.HasEmail();

        Assert.False(result);
    }

    [Fact]
    public void TestHasPhone_WhenOptionExists_ReturnsTrue()
    {
        var args = new string[] { Arg.PhoneOptions };
        var arg = new Arg(args);

        bool result = arg.HasPhone();

        Assert.True(result);
    }

    [Fact]
    public void TestHasPhone_WhenOptionDoesNotExist_ReturnsFalse()
    {
        var args = new string[] { Arg.CpfOption, Arg.CnpjOption };
        var arg = new Arg(args);

        bool result = arg.HasPhone();

        Assert.False(result);
    }

    [Fact]
    public void TestHasZipCode_WhenOptionExists_ReturnsTrue()
    {
        var args = new string[] { Arg.ZipCodeOptions };
        var arg = new Arg(args);

        bool result = arg.HasZipCode();

        Assert.True(result);
    }

    [Fact]
    public void TestHasZipCode_WhenOptionDoesNotExist_ReturnsFalse()
    {
        var args = new string[] { Arg.CpfOption, Arg.CnpjOption };
        var arg = new Arg(args);

        bool result = arg.HasZipCode();

        Assert.False(result);
    }

    [Theory]
    [InlineData(5, "-n", "5")]
    [InlineData(10, "-n10")]
    [InlineData(2, "-n 2")]
    public void TestQuantity_WhenOptionExists_ReturnsCorrectValue(int expected, params string[] args)
    {
        var arg = new Arg(args);

        int result = arg.Quantity;

        Assert.Equal(expected, result);
    }

    [Fact]
    public void TestQuantity_WhenOptionDoesNotExist_ReturnsDefaultValue()
    {
        var args = new string[] { Arg.CpfOption, Arg.EmailOptions };
        var arg = new Arg(args);

        int result = arg.Quantity;

        Assert.Equal(1, result);
    }

    [Theory]
    [InlineData("-h")]
    [InlineData("--help")]
    public void ShouldShowHelp_WhenHelpFlagIsPresent_ReturnsTrue(string option)
    {
        var args = new[] { option };
        var arg = new Arg(args);

        var result = arg.ShouldShowHelp();

        Assert.True(result);
    }

    [Fact]
    public void ShouldShowHelp_WhenHelpFlagIsNotPresent_ReturnsFalse()
    {
        var args = new string[] { Arg.CpfOption, Arg.EmailOptions };
        var arg = new Arg(args);

         var result = arg.ShouldShowHelp();

        Assert.False(result);
    }
}