using System.Text.RegularExpressions;

namespace FakerCLI
{
    public class Arg
    {
        private readonly string[] _args;

        public Arg(string[] args)
        {
            _args = args ?? throw new ArgumentNullException(nameof(args));
        }

        public static string QuantityOption => "-n";
        public static string CpfOption => "--cpf";
        public static string CnpjOption => "--cnpj";
        public static string FormatedOption => "--formated";
        public static string EmailOptions => "--email";
        public static string PhoneOptions => "--phone";
        public static string ZipCodeOptions => "--zipcode";

        public int Quantity => ExtractIntValue();

        public bool HasCpf() => _args.Contains(CpfOption);
        public bool HasCnpj() => _args.Contains(CnpjOption);
        public bool HasFormated() => _args.Contains(FormatedOption);
        public bool HasEmail() => _args.Contains(EmailOptions);
        public bool HasPhone() => _args.Contains(PhoneOptions);
        public bool HasZipCode() => _args.Contains(ZipCodeOptions);
        public bool ShouldShowHelp() => _args.Contains("--help") || _args.Contains("-h"); 

        public void ShowHelp()
        {
            Console.WriteLine("Faker-CLI  Options:");
            Console.WriteLine("--cpf: Generate CPF numbers");
            Console.WriteLine("--cnpj: Generate CNPJ numbers");
            Console.WriteLine("--email: Generate email addresses");
            Console.WriteLine("--phone: Generate phone numbers");
            Console.WriteLine("--zipcode: Generate zip codes");
            Console.WriteLine("--formated: Format the generated data");
            Console.WriteLine("-n <quantity>: Set the quantity of items to generate");
            Console.WriteLine("-h or --help: Show this help message");
        }

        private int ExtractIntValue()
        {
            var pattern = @$"\{QuantityOption}\s?\d+";
            var concatenatedArgs = string.Join("", _args);
            var regex = new Regex(pattern, RegexOptions.Compiled);

            if (regex.IsMatch(concatenatedArgs))
            {
                var match = regex.Match(concatenatedArgs).Value;
                return int.Parse(new string(match.Where(char.IsDigit).ToArray()));
            }
            return 1;
        }
    }
}