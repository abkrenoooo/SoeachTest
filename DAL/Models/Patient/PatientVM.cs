using DAL.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models.Patient
{
    public class PatientVM
    {
        [MaxLength(15)]
        [MinLength(2)]
        [Required]
        public string FirstName { get; set; }
        [MaxLength(15)]
        [MinLength(2)]
        [Required]
        public string SecondName { get; set; }
        [MaxLength(15)]
        [MinLength(2)]
        [Required]
        public string LastName { get; set; }
        [DataType(DataType.Date)]
        [Required]
        public DateTime? BirithDate { get; set; }
        [Required]
        public Gender Gender { get; set; }
        [Required]
        public OME? OME { get; set; }
        [Required]
        public OME? HearingTest { get; set; }
        [Required]
        public EducationState? EducationState { get; set; }
        public string? Note { get; set; }
        public int? SpecialistId { get; set; }
        public int? TestId { get; set; }
    }
}
