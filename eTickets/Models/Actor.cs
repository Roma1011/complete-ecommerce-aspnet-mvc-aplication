﻿using System.ComponentModel.DataAnnotations;

namespace eTickets.Models
{
	public class Actor
	{
		[Key]
		public int Id { get; set; }
		public string ProfilePictureURL { get; set; }
		public string Fullname { get; set; }
		public string Bio { get; set; }

	}
}