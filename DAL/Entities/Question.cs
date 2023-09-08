using SpeakEase.DAL.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Enum;
using DAL.Entities;

namespace SpeakEase.DAL.Entities
{
    public class Question
    {
        [Key]
        public int ChearId { get; set; }
        public CharacterPosition CharacterPosition { get; set; }
        public Character Character { get; set; }
        public string? Word { get; set; }
        public string? Image { get; set; }
        public string? Audio { get; set; }
        public bool IsDeleted { get; set; } = false;
        public bool IsHiden { get; set; } = false;

        public List<files>? files { get; set; }
    }
}
