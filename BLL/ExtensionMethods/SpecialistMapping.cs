
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
        public static async Task<Specialist> ToApplicationUser(this SpecialistVM specialistVM)
        {
            return new()
            {
                Accepted = specialistVM.Accepted,
                City = specialistVM.City,
                Country = specialistVM.Country,
                Hospital = specialistVM.Hospital,
                IdNumber = specialistVM.IdNumber,
                ImageOfSpecializationCertificate = specialistVM.ImageOfSpecializationCertificatePath,
                Status = specialistVM.Status,
                SpecialistId = specialistVM.SpecialistId,
                UserId = specialistVM.UserId
            };
        }

        public static async Task<SpecialistVM> FromApplicationUser(this Specialist specialist)
        {
            return new()
            {
                Accepted = specialist.Accepted,
                City = specialist.City,
                Country = specialist.Country,
                Hospital = specialist.Hospital,
                IdNumber = specialist.IdNumber,
                ImageOfSpecializationCertificatePath = specialist.ImageOfSpecializationCertificate,
                Status = specialist.Status,
                SpecialistId = specialist.SpecialistId,
                UserId = specialist.UserId,
                Email = specialist.User.Email,
                FirstName = specialist.User.FirstName,
                SecondName= specialist.User.SecondName,
                LastName = specialist.User.LastName,
                BirithDate= specialist.User.BirithDate,
                ConfirmPassword=specialist.C
            };
        }


    }
}
