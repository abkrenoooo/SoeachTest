using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Enum
{
    public enum ChearPositionResult
    {
        [Display(Name = "Berfore")]
        Berfore = 1,
        [Display(Name = "After")]
        After = 2,
        [Display(Name = "Non")]
        Non = 3,
    }
}
