namespace FakerCLI
{
    public class Arg
    {
        private readonly string[] _args;

        public Arg(string[] args)
        {
            _args = args ?? throw new ArgumentNullException(nameof(args));
        }

        public string QuantityOption => "-n";
        public string CpfOption => "--cpf";
        public string CnpjOption => "--cnpj";
        public string FormatedOption => "--formated";
        public string EmailOptions => "--email";
        public string PhoneOptions => "--phone";
        public string ZipCodeOptions => "--cep";

        public int Quantity => HasQuantity() ? ExtractIntValue(_args) : 1;
        public bool HasQuantity() => _args.Contains(QuantityOption);
        public bool HasCpf() => _args.Contains(CpfOption);
        public bool HasCnpj() => _args.Contains(CnpjOption);
        public bool HasFormated() => _args.Contains(FormatedOption);
        public bool HasEmail() => _args.Contains(EmailOptions);
        public bool HasPhone() => _args.Contains(PhoneOptions);
        public bool HasZipCode() => _args.Contains(ZipCodeOptions);

        private int ExtractIntValue(string[] args) 
            => int.Parse(string.Join("", string.Join("", args)
                  .ToArray<char>()
                  .Where(a => char.IsDigit(a))));
    }
}