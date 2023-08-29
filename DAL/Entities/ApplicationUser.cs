using DAL.Enum;
using Microsoft.AspNetCore.Identity;

namespace SpeakEase.DAL.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string LastName { get; set; }
        public DateTime? BirithDate { get; set; }
        public Gender Gender { get; set; }
        public bool Active { get; set; } = false;
    }
}
