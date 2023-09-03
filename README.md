# Faker-CLI

## Project Description

Faker-CLI is a command line tool that uses the Bogus Faker library to generate fake data in he terminal. Currently Faker-CLI supports the generation of CPF, CNPJ, Telephone, Email and CEP (Brazil ZipCode).

## Give a Star! ⭐
If you liked the project or if Faker-CLI helped you, please give a star ;)

## Requirements

Make sure you have .NET 7 installed on your system.

## Installation
Download the latest version according to your operating system [**here**](https://github.com/leandrodasilvaalves/faker-cli/releases).

> Assuming 1.0.0 is the latest version

### Linux

```bash
  cd ~/Downloads
  tar -xvf FakerCLI.linux.tar.gz
  chmod +x FakerCLI.1.0.0/faker #change 1.0.0 to your version
  sudo mv FakerCLI.1.0.0/ /usr/local/share/faker #change 1.0.0 to your version
  sudo ln -s /usr/local/share/faker/faker /usr/local/bin/faker
  faker --cpf
> 42825545503
```

### windows
Extract the downloaded binaries to the directory of your choice, for example, `c:\faker` and include this directory in your path according to the step by step [**here**](https://learn.microsoft.com/en-us/previous-versions/office/developer/sharepoint-2010/ee537574(v=office.14)#to-add-a-path-to-the-path-environment-variable).

Ater that open a terminal and type `--cpf`. You should see a generated number that looks like this: `42825545503`

## How to use
```bash
  faker --cpf --formated
  faker --cnpj --formated
  faker --phone --formated
  faker --email
  faker --zipcode --formated  
  faker --help #or -h
```
Use -n{x} where `x` is a number specifying the desired amount. Por exemplo:
``` bash
  faker --cpf -n10 # This will generate 10 random cpf numbers
```
> All options support the `-n` parameter.

## Contribution
This project is open source and contributions are welcome! Feel free to open issues and submit pull requests.

## License
The Faker-CLI Project was developed by [Leandro Alves](https://github.com/leandrodasilvaalves) under the MIT license.