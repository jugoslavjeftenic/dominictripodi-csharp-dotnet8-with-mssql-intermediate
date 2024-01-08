using Dapper;
using Microsoft.Data.SqlClient;
using System.Data;
using System.Globalization;
using T034_Dapper.Models;

string connectionString = "Server=(localdb)\\MSSQLLocalDB;Database=DotNetCourseDatabase;TrustServerCertificate=true;Trusted_Connection=true;";

IDbConnection dbConnection = new SqlConnection(connectionString);

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

//myComputer.ReleaseDate.ToString("yyyy-MM-dd")
//myComputer.Price.ToString("0.00", CultureInfo.InvariantCulture)

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

//dbConnection.Execute(sqlInsert);

string sqlSelect = @"SELECT 
	Computer.Motherboard,
	Computer.CPUCores,
	Computer.VideoCard,
	Computer.HasWifi,
	Computer.HasLTE,
	Computer.ReleaseDate,
	Computer.Price
FROM TutorialAppSchema.Computer";

IEnumerable<ComputerModel> computers = dbConnection.Query<ComputerModel>(sqlSelect);

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


