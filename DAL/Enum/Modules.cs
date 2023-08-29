using System.ComponentModel.DataAnnotations;

namespace DAL.Enum
{
    public enum Modules
    {
        [Display(Name = "Admin")]
        Admin = 1,
        [Display(Name = "Suber Admin")]
        SuberAdmin = 2,
        [Display(Name = "Specialist")]
        Specialist = 3,
        [Display(Name = "Test")]
        Test = 4,
        [Display(Name = "Question")]
        Question = 5,
        [Display(Name = "Result")]
        Result = 6,
        [Display(Name = "Patient")]
        Patient = 7,

    }
}