using DAL.Enum;
using DAL.Models.SpecialistModel;
using DAL.Repository.IRepository;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using SpeakEase.DAL.Data;
using SpeakEase.DAL.Entities;
using SpeakEase.Models;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository.Repository
{
    public class AdminRepo : IAdminRepo
    {
        private readonly ApplicationDbContext _db;
        private readonly UserManager<ApplicationUser> _userManager;

        public AdminRepo(UserManager<ApplicationUser> UserManager, ApplicationDbContext db)
        {
            _db = db;
            _userManager = UserManager;
        }

        public async Task<Response<AdminUserVM>> AddAdminUserAsync(AdminUserVM model)
        {
            throw new NotImplementedException();

            //var user = await _userManager.FindByEmailAsync(model.Email);
            //   if (!user.Active)
            //   {
            //       return new() { Message = "email is not active" };
            //   }
            //   if (user == null || !await _userManager.CheckPasswordAsync(user, model.Password))
            //       return new() { Message = "Invalid password or email" };


            //   // create token for the user
            //   var jwtSecurityToken = await CreateJwtToken(user);
            //   var studentRoles = await _userManager.GetRolesAsync(user);

            //var admin = model.();
            //var result = await _userManager.CreateAsync(admin, model.Password);

            ////specialist.UserId = _userManager.FindByNameAsync(model.Username).Result.Id;
            ////specialist.State = model.Status;
            //if (!result.Succeeded)
            //{
            //    var errors = string.Empty;

            //    foreach (var error in result.Errors)
            //        errors += $"{error.Description},";

            //    return new Response<AdminUserVM> { Message = errors };
            //}

            //await _userManager.AddToRoleAsync(admin, Roles.Admin.ToString());
            //return new Response<AdminUserVM>
            //{
            //    Success = true,
            //    ObjectData = new AdminUserVM()
            //    {
            //        Email = model.Email,
            //        ExpiresOn = jwtSecurityToken.ValidTo,
            //        IsAuthenticated = true,
            //        Roles = studentRoles.ToList(),
            //        Token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken),
            //        Username = user.UserName
            //    }
            //};
        }

        public Task<Response<AdminUserVM>> DeleteAdminUserAsync(int AdminUserId)
        {
            throw new NotImplementedException();
        }

        public Task<Response<AdminUserVM>> EditAdminUserAsync(AdminUserVM model)
        {
            throw new NotImplementedException();
        }

        public Task<Response<SpecialistVM>> EditeAdminUserInSpetialistRequstAsync(int SpetialistId)
        {
            throw new NotImplementedException();
        }

        public Task<Response<IList<SpecialistVM>>> GetAdminUserAllSpetialistRequstAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Response<AdminUserVM>> GetAdminUserByIdAsync(int AdminUserId)
        {
            throw new NotImplementedException();
        }

        public Task<Response<AdminUserVM>> GetAdminUsersAsync()
        {
            throw new NotImplementedException();
        }


        
    }
}
