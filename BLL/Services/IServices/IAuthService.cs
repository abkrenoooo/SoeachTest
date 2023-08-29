using SpeakEase.DAL.Entities;
using SpeakEase.Models;
using SpeakEase.Models.AuthModel;
using SpeakEase.Models.SpecialistModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.IServices
{
    public interface IAuthService
    {
        Task<Response<AuthModel>> RegisterUserAsync(SpecialistVM model);
        Task<Response<AuthModel>> LoginAsync(LoginUser login);
    }
}
