using System.ComponentModel.DataAnnotations;

namespace eTickets.Models
{
	public class Cinema
	{
		[Key]
		public int Id { get; set; }
		public string Logo { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		//Relationships Cinemas // There may be many films showing in the cinema
		public List<Movie>Movies { get; set; }
	}
}
