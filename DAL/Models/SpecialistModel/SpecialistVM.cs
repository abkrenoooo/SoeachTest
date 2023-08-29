using DAL.Enum;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace SpeakEase.Models.SpecialistModel
{
    public class SpecialistVM
    {
        public int? SpecialistID { get; set; }
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
        [Required]
        public Gender Gender { get; set; }
        [Required]
        public MaritalStatus Status { get; set; }
        [DataType(DataType.Date)]
        [Required]
        public DateTime BirithDate { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string? Password { get; set; }
        [Required]
        [Compare(nameof(Password), ErrorMessage = "Password don't match.")]
        [DataType(DataType.Password)]
        public string? ConfirmPassword { get; set; }
        [Required]
        public string Phone { get; set; }
        [Required]
        public string Username { get; set; }
        public string? ImageOfSpecializationCertificatePath { get; set; }
        [Required]
        public IFormFile ImageOfSpecializationCertificate { get; set; }
        [Required]
        public string Hospital { get; set; }
        [Required]
        public string Country { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string IdNumber { get; set; }
    }
}
