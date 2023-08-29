﻿using DAL.Enum;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SpeakEase.DAL.Entities
{
    public class Specialist
    {
        [Key]
        public int SpecialistId { get; set; }
        public string ImageOfSpecializationCertificate { get; set; }
        public string Hospital { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string IdNumber { get; set; }
        public MaritalStatus State { get; set; }
        public byte Accepted { get; set; } = 0;
        [ForeignKey(nameof(UserId))]
        public string UserId { get; set; }
        public virtual ApplicationUser User { get; set; }
        public virtual List<Patient>? Patients { get; set; }
        public virtual List<Test>? Tests { get; set; }

    }
}