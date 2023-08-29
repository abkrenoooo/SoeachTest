
using DAL.Models.SpecialistModel;
using SpeakEase.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.ExtensionMethods
{
    public static class AdminMapping
    {
        public static ApplicationUser ToApplicationUser(this AdminUserVM admin)
        {
            return new()
            {
                Id = Guid.NewGuid().ToString(),
                UserName = admin.Email,
                Email = admin.Email,
                FirstName = admin.FirstName,
                LastName = admin.LastName,
                PhoneNumber = admin.Phone,
                Active = true,
                BirithDate = admin.BirithDate,
                Gender = admin.Gender,
            };
        }

        public static AdminUserVM FromApplicationUser(this ApplicationUser user)
        {
            return new()
            {
                UserId = Guid.NewGuid().ToString(),
                Username = user.Email,
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Phone= user.PhoneNumber,
                Active = true,
                BirithDate = user.BirithDate,
                Gender = user.Gender,
                SecondName= user.SecondName,
            };
        }

        
    }
}
