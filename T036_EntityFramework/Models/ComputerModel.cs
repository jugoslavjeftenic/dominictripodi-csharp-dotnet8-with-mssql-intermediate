﻿using System.ComponentModel.DataAnnotations;

namespace T036_EntityFramework.Models
{
	internal class ComputerModel
	{
		[Key] public int ComputerId { get; set; }
		public string Motherboard { get; set; } = "";
		public int CPUCores { get; set; }
		public string VideoCard { get; set; } = "";
		public bool HasWifi { get; set; }
		public bool HasLTE { get; set; }
		public DateTime ReleaseDate { get; set; }
		public decimal Price { get; set; }
	}
}