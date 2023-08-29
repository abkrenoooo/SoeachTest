using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Enum
{
    public enum ChearState
    {
        [Display(Name = "Distortion")]
        Distortion = 1,
        [Display(Name = "Substitution")]
        Substitution = 2,
        [Display(Name = "Deletion")]
        Deletion = 3,
        [Display(Name = "Addition")]
        Addition = 4,
        [Display(Name = "Correct")]
        Correct = 5,
    }
}
