using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Enum
{
    public enum OME
    {
        [Display(Name = "NORMAL")]
        NORMAL = 1,
        [Display(Name = "ABNORMAL")]
        ABNORMAL = 2,
        [Display(Name = "Not Checked")]
        NotChecked = 3,
    }
}
