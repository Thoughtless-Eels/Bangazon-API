using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace thoughtless_eels.Models
{
    public class Computer
    {
        [Key]
        public int ComputerId {get; set;}

        [Required]
        public string Name {get; set;}
        
        [Required]
        [DataType(DataType.Date)]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime PurchasedOn { get; set; }

        [DataType(DataType.Date)]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime DecomissionedOn { get; set; }

        [Required]
        public int Malfunction {get; set;}

        [Required]
        public int Available {get; set;}
    
    }
}