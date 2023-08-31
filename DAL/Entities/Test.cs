using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace SpeakEase.DAL.Entities
{
    public class Test
    {
        public int TestId { get; set; }
        public string? TestName { get; set; }
        public DateTime? TestDate { get; set; }
        [ForeignKey(nameof(SpecialistId))]
        public int? SpecialistId { get; set; }
        public virtual Specialist? Specialist { get; set; }
        public virtual Patient? Patient { get; set; }
        public virtual List<Chear>? Chears { get; set; }
    }
}
