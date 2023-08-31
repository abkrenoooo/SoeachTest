using DAL.Models.Admin;
using DAL.Models.SpecialistModel;
using SpeakEase.DAL.Entities;
using SpeakEase.Models;
using SpeakEase.Models.AuthModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.IServices
{
    public interface IAdminSevices
    {
        public Task<Response<AuthModel>> AddAdminUserAsync(AdminUserVM model);//
        public Task<Response<AdminUserVM>> RemoveAdminUserAsync(string AdminUserId);//
        public Task<Response<AdminUserVM>> GetAdminUserByIdAsync(string AdminUserId);
        public Task<Response<ApplicationUser>> GetAdminUsersAsync(int paggingNumber);
        public Task<Response<AdminUserVM>> EditAdminUserAsync(AdminUserVM model);
        public Task<Response<Specialist>> GetAdminUserAllSpetialistRequstAsync(int paggingNumber);//
        public Task<Response<SpecialistVM>> EditAdminUserInSpetialistRequestAsync(int SpetialistId, bool Accepted);

    }
}
