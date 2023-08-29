using SpeakEase.Models;
using DAL.Models.SpecialistModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository.IRepository
{
    public interface IAdminRepo 
    {
        Task<Response<AdminUserVM>> AddAdminUserAsync(AdminUserVM model);
        Task<Response<AdminUserVM>> EditAdminUserAsync(AdminUserVM model);
        Task<Response<AdminUserVM>> DeleteAdminUserAsync(int AdminUserId);
        Task<Response<AdminUserVM>> GetAdminUserByIdAsync(int AdminUserId);
        Task<Response<AdminUserVM>> GetAdminUsersAsync();
        Task<Response<IList<SpecialistVM>>> GetAdminUserAllSpetialistRequstAsync();
        Task<Response<SpecialistVM>> EditeAdminUserInSpetialistRequstAsync(int SpetialistId);

    }
}
