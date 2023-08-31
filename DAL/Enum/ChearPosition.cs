using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Enum
{
    public enum ChearPosition
    {
        [Display(Name = "Initial First")]
        InitialFirst = 1,
        [Display(Name = "Initial Second")]
        InitialSecond = 2,
        [Display(Name = "Middle First")]
        MiddleFirst = 3,
        [Display(Name = "Middle Second")]
        MiddleSecond = 4,
        [Display(Name = "Final First")]
        FinalFirst = 5,
        [Display(Name = "Final Second")]
        FinalSecond = 6,
    }
}
