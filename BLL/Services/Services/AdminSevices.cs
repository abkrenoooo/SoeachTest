using Bll.ExtensionMethods;
using BLL.Services.IServices;
using DAL.Enum;
using DAL.Models.Admin;
using DAL.Models.SpecialistModel;
using DAL.Repository.IRepository;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using SpeakEase.BLL.Helper;
using SpeakEase.DAL.Data;
using SpeakEase.DAL.Entities;
using SpeakEase.Models;
using SpeakEase.Models.AuthModel;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.Services
{
    public class AdminSevices : IAdminSevices
    {
        private readonly ApplicationDbContext _db;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly JWT _jwt;
        private readonly IAdminRepo _adminRepo;
        private readonly ISpecialistServices _specialistServices;

        public AdminSevices(UserManager<ApplicationUser> UserManager, ApplicationDbContext db, IOptions<JWT> jwt, IAdminRepo adminRepo, ISpecialistServices specialistServices)
        {
            _db = db;
            _jwt = jwt.Value;
            _userManager = UserManager;
            _adminRepo = adminRepo;
            _specialistServices = specialistServices;
        }
        public async Task<Response<AuthModel>> AddAdminUserAsync(AdminUserVM model)
        {
            try
            {
                if (await _userManager.FindByEmailAsync(model.Email) is not null)
                    return new Response<AuthModel> { Message = "Email is already registered!" };

                if (await _userManager.FindByNameAsync(model.Username) is not null)
                    return new Response<AuthModel> { Message = "Username is already registered!" };

                var admin = await model.ToApplicationUser();
                var result = await _userManager.CreateAsync(admin, model.Password);

                if (!result.Succeeded)
                {
                    var errors = string.Empty;

                    foreach (var error in result.Errors)
                        errors += $"{error.Description},";
                    return new Response<AuthModel>
                    {
                        Success = false,
                        Message = errors,
                        status_code = "400",
                    };
                }
                //create token for the user

                var jwtSecurityToken = await CreateJwtToken(admin);
                var studentRoles = await _userManager.GetRolesAsync(admin);

                await _userManager.AddToRoleAsync(admin, Roles.Admin.ToString());
                return new Response<AuthModel>
                {
                    Success = true,
                    ObjectData = new AuthModel()
                    {
                        Email = model.Email,
                        ExpiresOn = jwtSecurityToken.ValidTo,
                        IsAuthenticated = true,
                        Roles = studentRoles.ToList(),
                        Token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken),
                        Username = admin.UserName
                    },
                    status_code = "200",
                };
            }
            catch (Exception ex)
            {
                return new Response<AuthModel>
                {
                    Success = false,
                    Message = ex.Message,
                    status_code = "400",
                };
            }

        }

        public async Task<Response<AdminUserVM>> RemoveAdminUserAsync(string AdminUserId)
        {
            try
            {
                if (!await _adminRepo.RemoveAdminUserAsync(AdminUserId))
                {
                    return new Response<AdminUserVM>
                    {
                        Success = false,
                        Message = "error!",
                        status_code = "400",
                    };
                }
                return new Response<AdminUserVM>
                {
                    Success = true,
                    Message = "admin has removed",
                    status_code = "200",
                };
            }
            catch (Exception ex)
            {
                return new Response<AdminUserVM>
                {
                    Success = false,
                    Message = ex.Message,
                    status_code = "400",
                };
            }
        }

        public async Task<Response<SpecialistVM>> EditAdminUserInSpetialistRequestAsync(int SpetialistId, bool Accepted)
        {
            try
            {
                var data = await _adminRepo.EditAdminUserInSpetialistRequestAsync(SpetialistId, Accepted);
                if (Accepted)
                {
                    if (data == null)
                    {
                        return new Response<SpecialistVM>
                        {
                            Success = false,
                            Message = "Error",
                            status_code = "400",
                        };
                    }
                    return new Response<SpecialistVM>
                    {
                        ObjectData = await data.FromSpecialist(),
                        Success = true,
                        Message = "Spetialist Request is Accepted",
                        status_code = "200",
                    };
                }
                else
                {
                    return await _specialistServices.DeleteSpecialistAsync(SpetialistId);
                }
            }
            catch (Exception ex)
            {
                return new Response<SpecialistVM>
                {
                    Success = false,
                    Message = ex.Message,
                    status_code = "400",
                };
            }
        }

        public async Task<Response<Specialist>> GetAdminUserAllSpetialistRequstAsync(int paggingNumber)
        {
            try
            {
                var result = await _adminRepo.GetAdminUserAllSpetialistRequstAsync(paggingNumber);

                if (result.Success)
                {
                    double pagging = Convert.ToInt32(result.CountOfData) / 10;
                    if (pagging % 10 == 0)
                    {
                        result.paggingNumber = (int)pagging;
                    }
                    else
                    {
                        result.paggingNumber = (int)pagging + 1;
                    }
                }
                return result;
            }
            catch (Exception ex)
            {
                return new Response<Specialist>
                {
                    Success = true,
                    Message = ex.Message,
                    status_code = "400",
                };
            }
        }

        public async Task<Response<AdminUserVM>> GetAdminUserByIdAsync(string AdminUserId)
        {
            try
            {
                var data = await _adminRepo.GetAdminUserByIdAsync(AdminUserId);
                if (data == null)
                {
                    return new Response<AdminUserVM>
                    {
                        Success = false,
                        Message = "Error",
                        status_code = "404",
                    };
                }
                return new Response<AdminUserVM>
                {
                    Success = true,
                    ObjectData = await data.FromApplicationUser(),
                    Message = "Data Found",
                    status_code = "200",
                };
            }
            catch (Exception ex)
            {
                return new Response<AdminUserVM>
                {
                    Success = true,
                    Message = ex.Message,
                    status_code = "400",
                };
            }
        }

        public async Task<Response<AdminUserVM>> EditAdminUserAsync(AdminUserVM model)
        {
            try
            {
                var data = await _adminRepo.EditAdminUserAsync(model.ToApplicationUserWithSamId().Result);
                if (data == null)
                {
                    return new Response<AdminUserVM>
                    {
                        Success = false,
                        Message = "Error",
                        status_code = "404",
                    };
                }
                return new Response<AdminUserVM>
                {
                    Success = true,
                    ObjectData = await data.FromApplicationUser(),
                    Message = "Data Found",
                    status_code = "200",
                };
            }
            catch (Exception ex)
            {
                return new Response<AdminUserVM>
                {
                    Success = true,
                    Message = ex.Message,
                    status_code = "400",
                };
            }
        }
        public async Task<Response<ApplicationUser>> GetAdminUsersAsync(int paggingNumber)
        {
            try
            {
                var result = await _adminRepo.GetAllAdminAsync(paggingNumber);

                if (result.Success)
                {
                    double pagging = Convert.ToInt32(result.CountOfData) / 10;
                    if (pagging % 10 == 0)
                    {
                        result.paggingNumber = (int)pagging;
                    }
                    else
                    {
                        result.paggingNumber = (int)pagging + 1;
                    }
                }
                return result;

            }
            catch (Exception ex)
            {
                return new Response<ApplicationUser>
                {
                    Success = true,
                    Message = ex.Message,
                    status_code = "400",
                };
            }
        }


        #region Private Methods
        private async Task<JwtSecurityToken> CreateJwtToken(ApplicationUser user)
        {
            var userClaims = await _userManager.GetClaimsAsync(user);
            var roles = await _userManager.GetRolesAsync(user);
            var roleClaims = new List<Claim>();

            foreach (var role in roles)
                roleClaims.Add(new Claim("roles", role));

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim("uid", user.Id)
            }
            .Union(userClaims)
            .Union(roleClaims);

            var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwt.Key));
            var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);

            var jwtSecurityToken = new JwtSecurityToken(
                issuer: _jwt.Issuer,
                audience: _jwt.Audience,
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(_jwt.DurationInMinutes),
                signingCredentials: signingCredentials);

            return jwtSecurityToken;
        }

        #endregion
    }
}
