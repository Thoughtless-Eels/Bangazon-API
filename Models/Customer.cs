using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace thoughtless_eels.Models
{
    public class Customer
    {
        [Key]
        public int CustomerId {get; set;}

        [Required]
        public string FirstName {get; set;}

        [Required]
        public string LastName {get; set;}


        [Required]
        [DataType(DataType.Date)]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime CreatedOn { get; set; }

        [Required]
        public int DaysInactive {get; set;}      
    }
}