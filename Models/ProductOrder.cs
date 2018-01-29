// Model for the ProductOrder Table:
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace thoughtless_eels.Models
{
    public class ProductOrder
    {
        // Establish the Primary Key:
        [Key]
        public int ProductOrderId { get; set; }

        [Required]
        public int ProductId { get; set; }
        public Product Product { get; set; }

        [Required]
        public int CurrentOrderId {get; set;}
        public CurrentOrder CurrentOrder {get; set;}
    }
}