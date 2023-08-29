using System.ComponentModel.DataAnnotations;

namespace SpeakEase.Models.SpecialistModel
{
    public class SpecialistVM
    {
        public string? SpecialistID { get; set; }
        [MaxLength(10)]
        [MinLength(5)]
        [Required]
        public string FullName { get; set; }
        [Required]
        public string SpecialistSpecialty { get; set; }
        
        public string Gender { get; set; }
        [DataType(DataType.Date)]
        [Required]
        public DateTime DateOfBirth { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
        [Required]
        public string Address { get; set; }
        public string Qualifications { get; set; }
        public int YearsOfExperience { get; set; }
        public string AdditionalDetails { get; set; }
    }
}
