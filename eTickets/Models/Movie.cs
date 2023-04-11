using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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
		//Relationship // Actor can play in many movies
		public List<Actor_Movie> Actor_Movies { get; set; }
		//Cinema // movie can be purchased from a single cinema
		public int CinemaId { get; set; }
		[ForeignKey("CinemaId")]
		public Cinema Cinema { get; set; }
		//Producere // Movies Have Single Producer
		public int ProducerId { get; set; }
		[ForeignKey("ProducerId")]
		public Producer Producer { get; set; }
	}
}
