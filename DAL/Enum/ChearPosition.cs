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
        [Display(Name = "Initial")]
        Initial = 1,
        [Display(Name = "Middle")]
        Middle = 2,
        [Display(Name = "Final")]
        Final = 3,
    }
}
