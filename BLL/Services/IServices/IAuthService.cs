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
    public interface IAuthService
    {
        Task<Response<AuthModel>> RegisterUserAsync(RegisterModel model);
        Task<Response<AuthModel>> LoginAsync(LoginUser login);
    }
}
