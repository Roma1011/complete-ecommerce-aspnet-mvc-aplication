using System.ComponentModel.DataAnnotations;
using eTickets.Data.Base;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace eTickets.Models
{
	public class Actor:IEntityBase
	{
		[Key]
		public int Id { get; set; }

		[Display(Name = "Profile Picture")]
		[Required(ErrorMessage = "Profile Picture is Required")]
		public string ProfilePictureURL { get; set; }

        [Display(Name = "Full Name")]
		[Required(ErrorMessage = "Full Name is Required")]
		[StringLength(50,MinimumLength = 3,ErrorMessage = "Full Name must be between 3 and chars")]
        public string Fullname { get; set; }

        [Display(Name = "Biography")]
		[Required(ErrorMessage = "Biography is Required")]
        public string Bio { get; set; }

		//Relationships // Actors can play multiple movies
        public List<Actor_Movie> Actors_Movies { get; set; } = new List<Actor_Movie>();
    }
}
