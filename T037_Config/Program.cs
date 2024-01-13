using Microsoft.Extensions.Configuration;
using T037_Config.Data;
using T037_Config.Models;

IConfiguration config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();

DataContextDapper dapper = new(config);
DataContextEF ef = new(config);

// Dapper
string sqlSelect = @"SELECT 
	Computer.ComputerId,
	Computer.Motherboard,
	Computer.CPUCores,
	Computer.VideoCard,
	Computer.HasWifi,
	Computer.HasLTE,
	Computer.ReleaseDate,
	Computer.Price
FROM TutorialAppSchema.Computer";

IEnumerable<ComputerModel> computersDapper = dapper.LoadData<ComputerModel>(sqlSelect);

foreach (var computer in computersDapper)
{
	string row = $"{computer.ComputerId}: ";
	row += $"[{computer.Motherboard}], ";
	row += $"[{computer.CPUCores}], ";
	row += $"[{computer.VideoCard}], ";
	row += $"[{computer.HasWifi}], ";
	row += $"[{computer.HasLTE}], ";
	row += $"[{computer.ReleaseDate}], ";
	row += $"[{computer.Price}]";

	Console.WriteLine(row);
}

Console.WriteLine();
Console.WriteLine();

// EntityFramework
IEnumerable<ComputerModel> computersEF = ef.Computer.ToList<ComputerModel>();

foreach (var computer in computersEF)
{
	string row = $"{computer.ComputerId}: ";
	row += $"[{computer.ComputerId}], ";
	row += $"[{computer.Motherboard}], ";
	row += $"[{computer.CPUCores}], ";
	row += $"[{computer.VideoCard}], ";
	row += $"[{computer.HasWifi}], ";
	row += $"[{computer.HasLTE}], ";
	row += $"[{computer.ReleaseDate}], ";
	row += $"[{computer.Price}]";

	Console.WriteLine(row);
}
