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
    public class QuestionVM
    {
        //public int QuestionId { get; set; }
        [Required]
        public string Word { get; set; }
        //public string? ImagePath { get; set; }
        //public string? AudioPath { get; set; }
        [Required]
        public IFormFile Image { get; set; }
        [Required]
        public IFormFile Audio { get; set; }
        [Required]
        public CharacterPosition ChearPosition { get; set; }
        [Required]
        public Character Character { get; set; }
    }
}
