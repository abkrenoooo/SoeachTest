using SpeakEase.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models.SpecialistModel
{
    public class TestVM
    {
        public int TestId { get; set; }

        public string? TestName { get; set; }
        public DateTime? TestDate { get; set; }
        public int? SpecialistId { get; set; }
        public virtual Specialist? Specialist { get; set; }
        public int? PatientId { get; set; }
        public virtual Patient? Patient { get; set; }
        public virtual List<Chear>? Chears { get; set; }
    }
}
