﻿
using DAL.Models.SpecialistModel;
using SpeakEase.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bll.ExtensionMethods
{
    public static class SpecialistMapping
    {
        public static async Task<Specialist> ToSpecialist(this SpecialistVM specialistVM)
        {
            return new()
            {
                IsAccepted = specialistVM.Accepted,
                City = specialistVM.City,
                Country = specialistVM.Country,
                Hospital = specialistVM.Hospital,
                IdNumber = specialistVM.IdNumber,
                ImageOfSpecializationCertificate = specialistVM.ImageOfSpecializationCertificatePath,
                MaritalStatus = specialistVM.MaritalStatus,
                SpecialistId = specialistVM.SpecialistId,
                UserId = specialistVM.UserId
            };
        }

        public static async Task<SpecialistVM> FromSpecialist(this Specialist specialist)
        {
            return new()
            {
                Accepted = specialist.IsAccepted ,
                City = specialist.City,
                Country = specialist.Country,
                Hospital = specialist.Hospital,
                IdNumber = specialist.IdNumber,
                ImageOfSpecializationCertificatePath = specialist.ImageOfSpecializationCertificate,
                MaritalStatus = specialist.MaritalStatus,
                SpecialistId = specialist.SpecialistId,
                UserId = specialist.UserId
            };
        }


    }
}
