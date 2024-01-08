namespace T026_Models
{
	public class Computer
	{
		public string Motherboard { get; set; } = "";
		public int CPUCores { get; set; }
		public string VideoCard { get; set; } = "";
		public bool HasWifi { get; set; }
		public bool HasLTE { get; set; }
		public DateTime ReleaseDate { get; set; }
		public decimal Price { get; set; }
	}

	internal class Program
	{
		private static void Main(string[] args)
		{
			Computer myComputer = new()
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
		}
	}
}
