using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using eTickets.Data.Base;
using eTickets.Data.Enums;

namespace eTickets.Models
{
    public class Movie:IEntityBase
	{
		[Key]
		public int Id { get; set; }

        [Display(Name = "Movie Name")]
        public string Name { get; set; }
        [Display(Name = "Movie Description")]
        public string Description { get; set; }
        [Display(Name = "Movie Price")]
        public Double Price { get; set; }
        [Display(Name = "Movie Image")]
        public string ImageUrl { get; set; }
        [Display(Name = "Movie Start Date")]
        public DateTime StratDate { get; set; }
        [Display(Name = "Movie End Date")]
        public DateTime EndDate { get; set; }
        [Display(Name = "Movie Category")]
        public MovieCategory MovieCategory { get; set; }
		//Relationship // Actor can play in many movies
		public List<Actor_Movie> Actors_Movies { get; set; }
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
