namespace T041_ModelMapping.Models
{
	internal class ComputerSnakeModel
	{
		public int computer_id { get; set; }
		public string motherboard { get; set; } = "";
		public int cpu_cores { get; set; } = 0;
		public string video_card { get; set; } = "";
		public bool has_wifi { get; set; }
		public bool has_lte { get; set; }
		public DateTime? release_date { get; set; }
		public decimal price { get; set; }
	}
}
