using System.ComponentModel.DataAnnotations;

namespace eTickets.Models
{
	public class Cinema
	{
		[Key]
		public int Id { get; set; }
        [Display(Name = "Cinema Logo")]
        public string Logo { get; set; }
        [Display(Name = "Cinema Name")]

        public string Name { get; set; }
        [Display(Name = "Cinema Description")]

        public string Description { get; set; }
		//Relationships Cinemas // There may be many films showing in the cinema
		public List<Movie>Movies { get; set; }
	}
}
