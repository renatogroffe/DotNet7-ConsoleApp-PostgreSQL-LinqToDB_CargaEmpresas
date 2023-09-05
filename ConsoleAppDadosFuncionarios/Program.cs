using Bogus;
using DustInTheWind.ConsoleTools.Controls.Tables;
using LinqToDB;
using LinqToDB.Data;
using ConsoleAppDadosFuncionarios.Inputs;
using ConsoleAppDadosFuncionarios.Data;

Console.WriteLine(
    "***** Carga de Dados utilizando .NET 7 + LinqToDB + PostgreSQL + Bogus (dados fake) *****");
Console.WriteLine();

var country = InputHelper.GetAnswerCountry();
var localeCode = InputHelper.GetLocaleCode(country);
var numberOfRecords = InputHelper.GetNumberOfRecords();
var connectionString = InputHelper.GetConnectionString();

var db = new DataConnection(new DataOptions()
    .UsePostgreSQL(connectionString));

var fakeFuncionarios = new Faker<Funcionario>(localeCode).StrictMode(false)
            .RuleFor(p => p.Nome, f => f.Name.FullName())
            .RuleFor(p => p.Email, (f, p) => f.Internet.Email(p.Nome))
            .RuleFor(p => p.Cidade, f => f.Address.City())
            .RuleFor(p => p.Pais, f => country)
            .Generate(numberOfRecords);

await db.BulkCopyAsync<Funcionario>(fakeFuncionarios);

Console.WriteLine();
var dataGrid = new DataGrid("Dados gerados em public.\"Funcionarios\"");
dataGrid.Columns.Add("* Funcionario *");
dataGrid.Columns.Add("* Email *");
dataGrid.Columns.Add("* Cidade *");
dataGrid.Columns.Add("* Pais *");
foreach (var funcionario in fakeFuncionarios)
    dataGrid.Rows.Add(funcionario.Nome, funcionario.Email, funcionario.Cidade, funcionario.Pais);
dataGrid.DisplayBorderBetweenRows = true;
Console.WriteLine();
dataGrid.Display();

Console.WriteLine();       