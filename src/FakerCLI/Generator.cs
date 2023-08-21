using AutoFixture;
using Bogus;
using Bogus.DataSets;
using Bogus.Extensions.Brazil;

namespace FakerCLI
{
    public class Generator
    {
        private readonly Arg _arg;

        private List<string> _fakersData;
        public IReadOnlyList<string> FakerData => _fakersData;

        public Generator(Arg arg)
        {
            _arg = arg ?? throw new ArgumentNullException(nameof(arg));
            _fakersData = new List<string>();
        }

        public void Generate()
        {
            var faker = new Faker();
            var fixture = new Fixture();
            fixture.Register(() => new Person("pt_BR"));
            fixture.Register(() => new Company("pt_BR"));
            fixture.Register(() => new PhoneNumbers("pt_BR"));
            fixture.Register(() => new Address("pt_BR"));

            if (_arg.HasCpf())
            {
                var people = fixture.CreateMany<Person>(_arg.Quantity);
                _fakersData.AddRange(people.Select(p => p.Cpf(_arg.HasFormated())));                
            }

            if(_arg.HasCnpj())
            {
                var companies = fixture.CreateMany<Company>(_arg.Quantity);
                _fakersData.AddRange(companies.Select(c => c.Cnpj(_arg.HasFormated())));
            }

            if(_arg.HasEmail())
            {
                var emails = fixture.CreateMany<Person>(_arg.Quantity).Select(p => p.Email.ToLower());
                _fakersData.AddRange(emails);
            }

            if(_arg.HasPhone())
            {
                var format = _arg.HasFormated() ? "(##) 9.####-####" : "##9########";
                var phones = fixture.CreateMany<PhoneNumbers>(_arg.Quantity).Select(p => p.PhoneNumber(format));
                _fakersData.AddRange(phones);
            }

            if(_arg.HasZipCode())
            {
                var format = _arg.HasFormated() ? "##.###-###" : "########";
                var zipcodes = fixture.CreateMany<Address>(_arg.Quantity).Select(e => e.ZipCode(format));
                _fakersData.AddRange(zipcodes);
            }
        }
    }
}