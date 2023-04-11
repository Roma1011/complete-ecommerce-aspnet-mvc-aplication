using System.ComponentModel.DataAnnotations;

namespace eTickets.Models
{
	public class Actor
	{
		[Key]
		public int Id { get; set; }
		public string ProfilePictureURL { get; set; }
		public string Fullname { get; set; }
		public string Bio { get; set; }
		//Relationships // Actors can play multiple movies
		public List<Actor_Movie>Actors_Movies { get; set; }
	}
}
