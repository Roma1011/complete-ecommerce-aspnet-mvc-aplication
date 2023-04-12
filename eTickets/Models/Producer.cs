using System.ComponentModel.DataAnnotations;

namespace eTickets.Models
{
	public class Producer
	{

		[Key]
		public int Id { get; set; }

		[Display(Name = "Profile Picture")]
		public string ProfilePictureURL { get; set; }
        [Display(Name = "Full Name")]
        public string Fullname { get; set; }
        [Display(Name = "Biography")]
        public string Bio { get; set; }

		//Relationships //producer can produce multiple movies
		public List<Movie>Movies { get; set; }
	}
}
