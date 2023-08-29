using DAL.Enum;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SpeakEase.DAL.Entities
{
    public class QuctionTest
    {
        [Key]
        public int QuctionTestId { get; set; }
        public ChearState? ChearState { get; set; }
        public int? TestId { get; set; }
        [ForeignKey(nameof(TestId))]
        public virtual Test? Test { get; set; } 
        public int? ChearId { get; set; }
        [ForeignKey(nameof(ChearId))]
        public virtual Chear? Chear { get; set; }  
        
    }
}
