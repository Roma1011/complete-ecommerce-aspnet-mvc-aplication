﻿using System.ComponentModel.DataAnnotations;

namespace eTickets.Models
{
	public class Actor
	{
		[Key]
		public int Id { get; set; }
		public string ProfilePictureURL { get; set; }
		public string Fulkname { get; set; }
		public string Bio { get; set; }

	}
}
