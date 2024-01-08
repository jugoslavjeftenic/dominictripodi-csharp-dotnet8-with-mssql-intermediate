using T028_Namespaces.Models;

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

myComputer.HasWifi = false;

Console.WriteLine(myComputer.Motherboard);
Console.WriteLine(myComputer.CPUCores);
Console.WriteLine(myComputer.VideoCard);
Console.WriteLine(myComputer.HasWifi);
Console.WriteLine(myComputer.HasLTE);
Console.WriteLine(myComputer.ReleaseDate);
Console.WriteLine(myComputer.Price);
