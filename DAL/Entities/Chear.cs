using SpeakEase.DAL.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Enum;

namespace SpeakEase.DAL.Entities
{
    public class Chear
    {
        [Key]
        public int ChearId { get; set; }
        public ChearPosition ChearPosition { get; set; }
        public Character Character { get; set; }
        public string? Word { get; set; }
        public string? Image { get; set; }
        public string? Audio { get; set; }
        [ForeignKey(nameof(TestId))]
        public int? TestId { get; set; }
        public virtual Test? Test { get; set; }
        public bool IsDeleted { get; set; } = false;
        public bool IsHiden { get; set; } = false;
    }
}
