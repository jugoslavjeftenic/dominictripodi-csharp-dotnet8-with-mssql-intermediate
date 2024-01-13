using AutoMapper;
using Microsoft.Extensions.Configuration;
using System.Text.Json;
using T041_ModelMapping.Data;
using T041_ModelMapping.Models;

IConfiguration config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
DataContextDapper dapper = new(config);

string computersSnakeJson = File.ReadAllText("ComputersSnake.json");

// ------------------------------------------------------------
// Automapper
Mapper mapper = new(new MapperConfiguration(
	cfg =>
	{
		cfg.CreateMap<ComputerSnakeModel, ComputerModel>()
		.ForMember(destination => destination.ComputerId, options => options.MapFrom(
			source => source.computer_id))
		.ForMember(destination => destination.Motherboard, options => options.MapFrom(
			source => source.motherboard))
		.ForMember(destination => destination.CPUCores, options => options.MapFrom(
			source => source.cpu_cores))
		.ForMember(destination => destination.VideoCard, options => options.MapFrom(
			source => source.video_card))
		.ForMember(destination => destination.HasWifi, options => options.MapFrom(
			source => source.has_wifi))
		.ForMember(destination => destination.HasLTE, options => options.MapFrom(
			source => source.has_lte))
		.ForMember(destination => destination.ReleaseDate, options => options.MapFrom(
			source => source.release_date))
		.ForMember(destination => destination.Price, options => options.MapFrom(
			source => source.price));
	}));


IEnumerable<ComputerSnakeModel>? computersSnakeAutomapper =
	JsonSerializer.Deserialize<IEnumerable<ComputerSnakeModel>>(computersSnakeJson);

if (computersSnakeAutomapper != null)
{
	IEnumerable<ComputerModel> computers = mapper.Map<IEnumerable<ComputerModel>>(computersSnakeAutomapper);

	foreach (var computer in computers)
	{
		Console.WriteLine(computer.Motherboard);
	}

	Console.WriteLine();
	Console.WriteLine(computers.Count());
}
// ------------------------------------------------------------
Console.WriteLine("--------------------------------------------");

// JsonPropertyMapping
IEnumerable<ComputerModel>? computersModelJsonPropertyMapping =
	JsonSerializer.Deserialize<IEnumerable<ComputerModel>>(computersSnakeJson);

if (computersModelJsonPropertyMapping != null)
{
	IEnumerable<ComputerModel> computers = mapper.Map<IEnumerable<ComputerModel>>(computersModelJsonPropertyMapping);

	foreach (var computer in computers)
	{
		Console.WriteLine(computer.Motherboard);
	}

	Console.WriteLine();
	Console.WriteLine(computers.Count());
}
