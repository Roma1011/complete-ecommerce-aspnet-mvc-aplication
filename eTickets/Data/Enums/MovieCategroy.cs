using System.ComponentModel.DataAnnotations;

namespace eTickets.Data.Enums
{
    public enum MovieCategory
    {
        [Display(Name = "Action")]
        Action=0,
        [Display(Name = "Comedy")]
        Comedy,
        [Display(Name = "Drama")]
        Drama,
        [Display(Name = "Horror")]
        Horror
    }
}
