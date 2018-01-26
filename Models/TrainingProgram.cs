using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace thoughtless_eels.Models
{
    public class TrainingProgram
    {
        [Key]
        public int TrainingProgramId {get; set;}

        [Required]
        public string TrainingProgramName {get; set;}

        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public string EndDate { get; set; }

        [Required]
        public int MaxAttendees {get; set;}

    }
}