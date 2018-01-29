using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace thoughtless_eels.Models
{
    public class ProductOrder
    {
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