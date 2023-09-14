using DAL.Enum;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SpeakEase.DAL.Entities
{
    public class Specialist
    {
        [Key]
        public int SpecialistId { get; set; }
        //public string? ImageOfSpecializationCertificate { get; set; }
        public string? Hospital { get; set; }
        public string? Country { get; set; }
        public string? City { get; set; }
        public string? IdNumber { get; set; }
        public MaritalStatus? MaritalStatus { get; set; }
        public bool? IsAccepted { get; set; } = false;
        [ForeignKey(nameof(UserId))]
        public string UserId { get; set; }
        public virtual ApplicationUser User { get; set; }
        public virtual List<Patient>? Patients { get; set; }

    }
}
