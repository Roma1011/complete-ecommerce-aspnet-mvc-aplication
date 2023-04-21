using System.ComponentModel.DataAnnotations;
using eTickets.Data.Enums;

namespace eTickets.Data.ModelView
{
    public class MovieVM
    {
        [Display(Name = "Movie Name")]
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

        [Display(Name = "Movie Description")]
        [Required(ErrorMessage = "Description is required")]
        public string Description { get; set; }

        [Display(Name = "Movie Price in $")]
        [Required(ErrorMessage = "Price is required")]
        public Double Price { get; set; }

        [Display(Name = "Movie poster URL")]
        [Required(ErrorMessage = "Poster is required")]
        public string ImageUrl { get; set; }

        [Display(Name = "Movie Start Date")]
        [Required(ErrorMessage = "Date is required")]
        public DateTime StratDate { get; set; }

        [Display(Name = "Movie End Date")]
        [Required(ErrorMessage = "Date is required")]
        public DateTime EndDate { get; set; }

        [Display(Name = "Movie Category")]
        [Required(ErrorMessage = "Category is required")]
        public MovieCategory MovieCategory { get; set; }

        [Display(Name = "Select a actors(s)")]
        [Required(ErrorMessage = "actors is required")]
        public List<int> ActorIds { get; set; }

        [Display(Name = "Select cinema")]
        [Required(ErrorMessage = "cinema is required")]
        public int CinemaId { get; set; }

        [Display(Name = "Select a producer")]
        [Required(ErrorMessage = "producer is required")]
        public int ProducerId { get; set; }
    }
}
