using T036_EntityFramework.Data;
using T036_EntityFramework.Models;

DataContextEF entityFramework = new();

ComputerModel myComputer = new()
{
	Motherboard = "B550",
	CPUCores = 6,
	VideoCard = "RX 470",
	HasWifi = true,
	HasLTE = true,
	ReleaseDate = DateTime.Now,
	Price = 948.87m
};

// Add to DB
//entityFramework.Add(myComputer);
//entityFramework.SaveChanges();

// Read from DB
IEnumerable<ComputerModel> computers = entityFramework.Computer.ToList<ComputerModel>();

int recordNo = 1;
foreach (var computer in computers)
{
	string row = $"{recordNo++}: ";
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
