using System.Globalization;
using T039_FileReadAndWrite.Models;

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

File.WriteAllText("log.txt", sqlInsert);

using StreamWriter openFile = new("log.txt", append: true);
openFile.WriteLine(sqlInsert);
openFile.Close();

Console.WriteLine(File.ReadAllText("log.txt"));
