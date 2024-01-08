using System.Globalization;
using T034_Dapper.Data;
using T034_Dapper.Models;

DataContextDapper dapper = new();

ComputerModel myComputer = new()
{
	Motherboard = "Z690",
	CPUCores = 8,
	VideoCard = "RTX 2060",
	HasWifi = true,
	HasLTE = true,
	ReleaseDate = DateTime.Now,
	Price = 948.87m
};

string sqlInsert = @$"INSERT INTO TutorialAppSchema.Computer (
	Motherboard,
	CPUCores,
	VideoCard,
	HasWifi,
	HasLTE,
	ReleaseDate,
	Price
) VALUES (
	'{myComputer.Motherboard}',
	'{myComputer.CPUCores}',
	'{myComputer.VideoCard}',
	'{myComputer.HasWifi}',
	'{myComputer.HasLTE}',
	'{myComputer.ReleaseDate:yyyy-MM-dd}',
	'{myComputer.Price.ToString("0.00", CultureInfo.InvariantCulture)}')";

//dapper.ExecuteSql(sqlInsert);

string sqlSelect = @"SELECT 
	Computer.Motherboard,
	Computer.CPUCores,
	Computer.VideoCard,
	Computer.HasWifi,
	Computer.HasLTE,
	Computer.ReleaseDate,
	Computer.Price
FROM TutorialAppSchema.Computer";

IEnumerable<ComputerModel> computers = dapper.LoadData<ComputerModel>(sqlSelect);

int recordNo = 1;
foreach (var computer in computers)
{
	string row = $"{recordNo++}: ";
	row += $"[{computer.Motherboard}], ";
	row += $"[{computer.CPUCores}], ";
	row += $"[{computer.VideoCard}], ";
	row += $"[{computer.HasWifi}], ";
	row += $"[{computer.HasLTE}], ";
	row += $"[{computer.ReleaseDate}], ";
	row += $"[{computer.Price}]";

	Console.WriteLine(row);
}
