using DAL.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models.Patient
{
    public class PatientVM
    {
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string LastName { get; set; }
        public DateTime? BirithDate { get; set; }
        public Gender Gender { get; set; }
        public OME? OME { get; set; }
        public OME? HearingTest { get; set; }
        public EducationState? EducationState { get; set; }
        public string? Note { get; set; }
        public int? SpecialitId { get; set; }
    }
}
