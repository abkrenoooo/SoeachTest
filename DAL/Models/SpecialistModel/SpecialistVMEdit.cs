using DAL.Enum;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace DAL.Models.SpecialistModel
{
    public class SpecialistVMEdit
    {
        [Required]
        public int SpecialistId { get; set; }
        [MaxLength(15)]
        [MinLength(2)]
        public string? FirstName { get; set; }
        [MaxLength(15)]
        [MinLength(2)]
        public string? SecondName { get; set; }
        [MaxLength(15)]
        [MinLength(2)]
        public string? LastName { get; set; }
        public Gender? Gender { get; set; }
        public MaritalStatus MaritalStatus { get; set; }
        [DataType(DataType.Date)]
        public DateTime? BirithDate { get; set; }
        //[DataType(DataType.EmailAddress)]
        //public string? Email { get; set; }
        //[DataType(DataType.Password)]
        //public string? Password { get; set; }
        //[Compare(nameof(Password), ErrorMessage = "Password don't match.")]
        //[DataType(DataType.Password)]
        //public string? ConfirmPassword { get; set; }
        public string? Phone { get; set; }
        //public string? Username { get; set; }
        //public string? ImageOfSpecializationCertificatePath { get; set; }
        //public IFormFile? ImageOfSpecializationCertificate { get; set; }
        public string? Hospital { get; set; }
        public string? Country { get; set; }
        public string? City { get; set; }
        public string? IdNumber { get; set; }
        //public string? UserId { get; set; }
        public bool Accepted { get; set; } = false;

    }
}
