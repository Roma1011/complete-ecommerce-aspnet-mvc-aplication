using eTickets.Data;
using eTickets.Data.Base;
using eTickets.Models;

namespace eTickets.Services.Cinemas
{
    public class CinemaService:EntityBaseRepository<Cinema>,ICinemasService
    {
        public CinemaService(AppDbContext context):base(context) { }
    }
}
