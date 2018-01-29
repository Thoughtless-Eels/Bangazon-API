// Model for the Employee/Computer Joiner Table:
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace thoughtless_eels.Models
{
    public class EmployeeComputer
    {
        [Key]
        public int EmployeeComputerId {get; set;}

        [Required]
        public int EmployeeId {get; set;}
        public Employee Employee {get; set;}

        [Required]
        public int ComputerId {get; set;}
        public Computer Computer {get; set;}


        [Required]
        [DataType(DataType.Date)]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime StartDate { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime EndDate { get; set; }

    }
}