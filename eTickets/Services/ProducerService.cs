using eTickets.Data;
using eTickets.Data.Base;
using eTickets.Models;

namespace eTickets.Services
{
    public class ProducerService:EntityBaseRepository<Producer>,IProducerService
    {
        public ProducerService(AppDbContext context):base(context){ }
    }
}
