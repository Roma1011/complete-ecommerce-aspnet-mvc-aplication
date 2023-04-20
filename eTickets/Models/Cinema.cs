using System.ComponentModel.DataAnnotations;
using eTickets.Data.Base;

namespace eTickets.Models
{
	public class Cinema:IEntityBase
	{
		[Key]
		public int Id { get; set; }

        [Display(Name = "Cinema Logo")]
		[Required(ErrorMessage = "Cinema Logo is Required")]
        public string Logo { get; set; }

        [Display(Name = "Cinema Name")]
        [Required(ErrorMessage = "Cinema Name is Required")]
        public string Name { get; set; }

        [Display(Name = "Cinema Description")]
        [Required(ErrorMessage = "Cinema Description is Required")]
        public string Description { get; set; }
		//Relationships Cinemas // There may be many films showing in the cinema
		public List<Movie>Movies { get; set; }=new List<Movie>();
	}
}
