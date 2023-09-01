using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using DAL.Enum;

namespace SpeakEase.DAL.Entities
{
    public class Result
    {
        [Key]
        public int ResultId { get; set; }
        public CharacterState ChearState { get; set; }
        public Character? AnotherCharacter { get; set; }
        public CharacterPositionResult? ChearPositionResult { get; set; }
        public bool IsDeleted { get; set; } = false;
        public int? ChearId { get; set; }
        [ForeignKey(nameof(ChearId))]
        public virtual Question? Chear { get; set; }
        public int? PatientId { get; set; }
        [ForeignKey(nameof(PatientId))]
        public virtual Patient? Patient { get; set; }
        public int? SpecialistId { get; set; }
        [ForeignKey(nameof(SpecialistId))]
        public virtual Specialist? Specialist { get; set; }
    }
}
