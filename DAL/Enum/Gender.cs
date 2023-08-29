using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Enum
{
    public enum Gender
    {
        [Display(Name = "Male")]
        Male=1,
        [Display(Name = "Female")]
        Female=2,
    }
}
