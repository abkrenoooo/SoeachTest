using DAL.Enum;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SpeakEase.DAL.Entities
{
    public class QuestionTest
    {
        [Key]
        public int QuctionTestId { get; set; }
        public ChearState? ChearState { get; set; }
        public int? ChearId { get; set; }
        [ForeignKey(nameof(ChearId))]
        public virtual Chear? Chear { get; set; }  
        
    }
}
