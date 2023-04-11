using System.ComponentModel.DataAnnotations;
using eTickets.Data.Enums;

namespace eTickets.Models
{
    public class Movie
	{
		[Key]
		public int Id { get; set; }

		public string Name { get; set; }
		public string Description { get; set; }
		public Double Price { get; set; }
		public string ImageUrl { get; set; }
		public DateTime StratDate { get; set; }
		public DateTime EmdDate { get; set; }
		public MovieCategory MovieCategory { get; set; }
	}
}
