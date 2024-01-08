namespace T034_Dapper.Models
{
	internal class ComputerModel
	{
		public string Motherboard { get; set; } = "";
		public int CPUCores { get; set; }
		public string VideoCard { get; set; } = "";
		public bool HasWifi { get; set; }
		public bool HasLTE { get; set; }
		public DateTime ReleaseDate { get; set; }
		public decimal Price { get; set; }
	}
}
