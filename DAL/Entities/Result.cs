using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using DAL.Enum;

namespace SpeakEase.DAL.Entities
{
    public class Result
    {
        [Key]
        public int ResultId { get; set; }
        public ChearState ChearState { get; set; }
        public Character? AnotherCharacter { get; set; }
        public ChearPositionResult ChearPositionResult { get; set; }
        public int? ChearId { get; set; }
        [ForeignKey(nameof(ChearId))]
        public virtual Chear? Chear { get; set; }
    }
}
