using DAL.Enum;
using DAL.Models.SpecialistModel;
using DAL.Repository.IRepository;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
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

        public async Task<bool> RemoveAdminUserAsync(string AdminUserId)
        {
            var admin = await _userManager.FindByIdAsync(AdminUserId);
            _db.Remove(admin);
            var result = await _db.SaveChangesAsync();
            return result > 0 ? true : false;
        }

        public Task<AdminUserVM> EditAdminUserAsync(AdminUserVM model)
        {
            throw new NotImplementedException();
        }

        public Task<SpecialistVM> EditeAdminUserInSpetialistRequstAsync(int SpetialistId)
        {
            throw new NotImplementedException();
        }

        public async Task<List<SpecialistVM>> GetAdminUserAllSpetialistRequstAsync()
        {
            var data = await _db.Specialists.Where(x => x.Accepted == false).ToListAsync();

        }

        public Task<AdminUserVM> GetAdminUserByIdAsync(string AdminUserId)
        {
            throw new NotImplementedException();
        }

        public Task<AdminUserVM> GetAdminUsersAsync()
        {
            throw new NotImplementedException();
        }



    }
}
