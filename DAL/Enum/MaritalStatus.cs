using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Enum
{
    public enum MaritalStatus
    {
        [Display(Name = "Single")]
        Single = 1,
        [Display(Name = "Married")]
        Married = 2,
        [Display(Name = "Separated")]
        Separated = 3,
        [Display(Name = "Engaged")]
        Engaged = 3,
        [Display(Name = "Spinster")]
        Spinster = 5,
        [Display(Name = "Divorced")]
        Divorced = 6,
        [Display(Name = "Widow / Widower")]
        Widow = 7,
    }
}
