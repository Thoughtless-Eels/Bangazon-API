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
        [DataType(DataType.Date)]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime StartDate { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime EndDate { get; set; }

        [Required]
        public int MaxAttendees {get; set;}

    }
}