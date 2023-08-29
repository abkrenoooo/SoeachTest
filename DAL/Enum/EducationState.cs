using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Enum
{
    public enum EducationState
    {
        [Display(Name = "Without Studying")]
        WithoutStudying = 1,
        [Display(Name = "Early Childhood Stage")]
        EarlyChildhoodStage = 2,
        [Display(Name = "Primary Stage")]
        PrimaryStage = 3,
        [Display(Name = "Middle Stage")]
        MiddleStage = 3,
        [Display(Name = "Secondary Stage")]
        SecondaryStage = 5,
        [Display(Name = "University Stage")]
        UniversityStage = 6,
        
    }
}
