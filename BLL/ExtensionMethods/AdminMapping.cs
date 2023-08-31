
using DAL.Models.Admin;
using SpeakEase.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bll.ExtensionMethods
{
    public static class AdminMapping
    {
        public static async Task<ApplicationUser> ToApplicationUser(this AdminUserVM admin)
        {
            return new()
            {
                Id = Guid.NewGuid().ToString(),
                UserName = admin.Username,
                Email = admin.Email,
                FirstName = admin.FirstName,
                SecondName = admin.SecondName,
                LastName = admin.LastName,
                PhoneNumber = admin.Phone,
                Active = true,
                BirithDate = admin.BirithDate,
                Gender = admin.Gender,
            };
        } 
        public static async Task<ApplicationUser> ToApplicationUserWithSamId(this AdminUserVM admin)
        {
            return new()
            {
                Id = admin.UserId,
                UserName = admin.Username,
                Email = admin.Email,
                FirstName = admin.FirstName,
                SecondName = admin.SecondName,
                LastName = admin.LastName,
                PhoneNumber = admin.Phone,
                Active = true,
                BirithDate = admin.BirithDate,
                Gender = admin.Gender,
            };
        }

        public static async Task<AdminUserVM> FromApplicationUser(this ApplicationUser user)
        {
            return new()
            {
                UserId = user.Id,
                Username = user.UserName,
                Email = user.Email,
                FirstName = user.FirstName,
                SecondName = user.SecondName,
                LastName = user.LastName,
                Phone = user.PhoneNumber,
                Active = true,
                BirithDate = user.BirithDate,
                Gender = user.Gender,
            };
        }


    }
}
