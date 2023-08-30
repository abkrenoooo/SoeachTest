using SpeakEase.Models;
using DAL.Models.SpecialistModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpeakEase.DAL.Entities;

namespace DAL.Repository.IRepository
{
    public interface IAdminRepo
    {
        public Task<ApplicationUser> EditAdminUserAsync(ApplicationUser model);
        public Task<bool> RemoveAdminUserAsync(string AdminUserId);
        public Task<ApplicationUser> GetAdminUserByIdAsync(string AdminUserId);
        public Task<Response<Specialist>> GetAdminUserAllSpetialistRequstAsync(int paggingNumber);
        public Task<Specialist> EditAdminUserInSpetialistRequestAsync(int SpetialistId, bool Accepted);
        public Task<Response<ApplicationUser>> GetAllAdminAsync(int paggingNumber);

    }
}
