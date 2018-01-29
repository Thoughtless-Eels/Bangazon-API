// // Model for the Employee Table:
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace thoughtless_eels.Models
{
    public class Employee
    {
        [Key]
        public int EmployeeId {get; set;}

        [Required]
        public string Name {get; set;}
        
        [Required]
        public int Supervisor {get; set;}

        [Required]
        public int DepartmentId {get; set;}
        public Department Department {get; set;}
    
    }
}