using DAL.Models.SpecialistModel;
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
        Task<Response<AuthModel>> AddAdminUserAsync(AdminUserVM model);//
        Task<Response<AdminUserVM>> RemoveAdminUserAsync(string AdminUserId);//
        Task<Response<AdminUserVM>> GetAdminUserByIdAsync(string AdminUserId);
        Task<Response<AdminUserVM>> GetAdminUsersAsync();
        Task<Response<IList<SpecialistVM>>> GetAdminUserAllSpetialistRequstAsync();//
        Task<Response<SpecialistVM>> EditeAdminUserInSpetialistRequstAsync(int SpetialistId);

    }
}
