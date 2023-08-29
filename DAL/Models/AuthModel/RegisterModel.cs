using DAL.Enum;
using System.ComponentModel.DataAnnotations;

namespace SpeakEase.Models.AuthModel
{
    public class RegisterModel
    {
        [StringLength(20)]
        public string FirstName { get; set; }
        public string SecondName { get; set; }

        [StringLength(20)]
        public string LastName { get; set; }

        [StringLength(50)]
        public string Username { get; set; }

        [StringLength(128)]
        public string Email { get; set; }

        [StringLength(20)]
        public string Password { get; set; }
        public DateTime? BirithDate { get; set; }
        public Gender Gender { get; set; }
         
    }
}
