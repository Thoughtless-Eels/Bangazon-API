// Model for the Product Table:
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace thoughtless_eels.Models
{
    public class Product
    {
        [Key]
        public int ProductId {get; set;}

        [Required]
        public string ProductName {get; set;}
        
        [Required]
        public double Price {get; set;}

        [Required]
        public int Quantity {get; set;}

        [Required]
        public string Description {get; set;}

        [Required]
        public int CustomerId {get; set;}
        public Customer Customer {get; set;}

        [Required]
        public int ProductTypeId {get; set;}
        public ProductType ProductType {get; set;}        
    }
}