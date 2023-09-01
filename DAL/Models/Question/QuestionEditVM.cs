using DAL.Enum;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models.Question
{
    public class QuestionEditVM
    {
        [Required]
        public int ChearId { get; set; }
        public string? Word { get; set; }
        public string? ImagePath { get; set; }
        public string? AudioPath { get; set; }
        public IFormFile? Image { get; set; }
        public IFormFile? Audio { get; set; }
        public CharacterPosition? ChearPosition { get; set; }
        public Character? Character { get; set; }
        public bool? IsDeleted { get; set; } = false;
        public bool? IsHiden { get; set; } = false;
    }
}
