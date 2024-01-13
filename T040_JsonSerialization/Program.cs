using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Globalization;
using System.Text.Json;
using T040_JsonSerialization;
using T040_JsonSerialization.Data;
using T040_JsonSerialization.Models;

IConfiguration config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
DataContextDapper dapper = new(config);

string computersJson = File.ReadAllText("Computers.json");
//Console.WriteLine(computersJson);

// ------------------------------------------------------------
// Serijalizacija/Deserijalizacija preko novog System.Text.Json
JsonSerializerOptions options = new() { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };

IEnumerable<ComputerModel>? computersSystem =
	System.Text.Json.JsonSerializer.Deserialize<IEnumerable<ComputerModel>>(computersJson, options);

string computersCopySystem = System.Text.Json.JsonSerializer.Serialize(computersSystem, options);
File.WriteAllText("ComputersCopySystem.json", computersCopySystem);


// Serijalizacija/Deserijalizacija preko starog Newtonsoft.Json
JsonSerializerSettings settings = new() { ContractResolver = new CamelCasePropertyNamesContractResolver() };

IEnumerable<ComputerModel>? computersNewtonsoft =
	JsonConvert.DeserializeObject<IEnumerable<ComputerModel>>(computersJson);

string computersCopyNewtonsoft = JsonConvert.SerializeObject(computersSystem, settings);
File.WriteAllText("ComputersCopyNewtonsoft.json", computersCopyNewtonsoft);
// ------------------------------------------------------------


if (computersSystem != null)
{
	foreach (var computer in computersSystem)
	{
		string sqlInsert = @$"INSERT INTO TutorialAppSchema.Computer (
			Motherboard,
			CPUCores,
			VideoCard,
			HasWifi,
			HasLTE,
			ReleaseDate,
			Price
		) VALUES (
			'{HelperMethods.EscapeSingleQuote(computer.Motherboard)}',
			'{computer.CPUCores}',
			'{HelperMethods.EscapeSingleQuote(computer.VideoCard)}',
			'{computer.HasWifi}',
			'{computer.HasLTE}',
			'{computer.ReleaseDate:yyyy-MM-dd}',
			'{computer.Price.ToString("0.00", CultureInfo.InvariantCulture)}')";

		dapper.ExecuteSql(sqlInsert);
	}
}
