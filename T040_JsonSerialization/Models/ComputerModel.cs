namespace T040_JsonSerialization.Models
{
	internal class ComputerModel
	{
		public int ComputerId { get; set; }
		public string Motherboard { get; set; } = "";
		public int CPUCores { get; set; } = 0;
		public string VideoCard { get; set; } = "";
		public bool HasWifi { get; set; }
		public bool HasLTE { get; set; }
		public DateTime? ReleaseDate { get; set; }
		public decimal Price { get; set; }
	}
}
