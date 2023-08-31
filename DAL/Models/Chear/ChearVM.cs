﻿using DAL.Enum;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models.Chear
{
    public class ChearVM
    {
        public int ChearId { get; set; }
        [Required]
        public string Word { get; set; }
        public string? ImagePath { get; set; }
        public string? AudioPath { get; set; }
        [Required]
        public IFormFile Image { get; set; }
        [Required]
        public IFormFile Audio { get; set; }
        [Required]
        public ChearPosition ChearPosition { get; set; }
        [Required]
        public Character Character { get; set; }
        public bool IsDeleted { get; set; } = false;
        public bool IsHiden { get; set; } = false;
    }
}
