using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace thoughtless_eels.Models
{
    public class CurrentOrder
    {
        [Key]

        public int CurrentOrderId { get; set; }

        [Required]
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }

        [Required]
        public int PaymentTypeId {get; set;}
        public PaymentType PaymentType {get; set;}
    }
}