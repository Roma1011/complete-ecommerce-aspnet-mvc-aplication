using System.ComponentModel.DataAnnotations;

namespace eTickets.Models
{
	public class Sinema
	{
		[Key]
		public int Id { get; set; }
		public string Logo { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
	}
}
