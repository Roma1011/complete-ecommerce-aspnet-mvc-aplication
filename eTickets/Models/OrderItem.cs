﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eTickets.Models
{
    public class OrderItem
    {
        [Key]
        public int Id { get; set; }

        public int Amount { get; set; }

        public double Pice { get; set; }


        public int MovieId { get; set; }
        public virtual Movie Movie { get; set; }
        public int OrderId { get; set; }
        public virtual Order Order { get; set; }
    }
}
