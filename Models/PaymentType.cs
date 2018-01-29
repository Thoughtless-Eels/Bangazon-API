// Model for the Payment Type Table:
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace thoughtless_eels.Models
{
    public class PaymentType
    {
        // Establish the Primary Key:
        [Key]
        public int PaymentTypeId {get; set;}

        [Required]
        public string Name {get; set;}

        [Required]
        public int AccountNumber {get; set;}

        [Required]
        public int CustomerId {get; set;}
        public Customer Customer {get; set;}         
    }
}