using System.ComponentModel.DataAnnotations;

namespace SpeakEase.Models.AuthModel
{
    public class UpdatePassword
    {
        [Required]
        [MinLength(8)]
        [MaxLength(20)]
        [DataType(DataType.Password)]
        public string NewPassword { get; set; }
        [Required]
        [MinLength(8)]
        [MaxLength(20)]
        [DataType(DataType.Password)]
        public string OldPassword { get; set; }

    }
}
