using DAL.Enum;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SpeakEase.DAL.Entities
{
    public class Patient 
    {
        [Key]
        public int PatientId { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string LastName { get; set; }
        public DateTime? BirithDate { get; set; }
        public DateTime? StartDate { get; set; }
        public Gender Gender { get; set; }
        public OME? OME { get; set; }
        public OME? HearingTest { get; set; }
        public EducationState? EducationState { get; set; }
        public int? SpecialistId { get; set; }
        [ForeignKey(nameof(SpecialistId))]
        public virtual Specialist? Specialist { get; set; }
        public string? Note { get; set; }
    }
}
