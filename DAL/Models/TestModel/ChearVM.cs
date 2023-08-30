using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models.TestModel
{
    public class ChearVM
    {
        [Required]
        public string Word { get; set; }
        [Required]

        public IFormFile Image { get; set; }
        [Required]

        public IFormFile? Audio { get; set; }
        [Required]

        public int? TestId { get; set; }
    }
}
