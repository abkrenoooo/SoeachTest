using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


namespace SpeakEase.DAL.Entities
{
    public class Result
    {
        [Key]
        public int ResultId { get; set; }
        public int Degree { get; set; }
        public int? TestId { get; set; }
        [ForeignKey(nameof(TestId))]
        public virtual Test? Test { get; set; }
    }
}
