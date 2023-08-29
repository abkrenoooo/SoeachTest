using System.ComponentModel.DataAnnotations;

namespace SpeakEase.Models.AuthModel
{
    public class UpdateVM
    {
        [StringLength(20)]
        public string FirstName { get; set; }

        [StringLength(20)]
        public string LastName { get; set; }
    }
}
