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
            if (admin != null)
            {
                _db.Users.Remove(admin);
                var result = await _db.SaveChangesAsync();
                return result > 0 ? true : false;
            }
            return false;
        }

        public async Task<ApplicationUser> EditAdminUserAsync(ApplicationUser model)
        {
            try
            {
                var user = await _userManager.FindByIdAsync(model.Id);
                if (user != null && model != null)
                {
                    user.SecondName = model.SecondName;
                    user.FirstName = model.FirstName;
                    user.LastName = model.LastName;
                    user.Gender = model.Gender;
                    user.PhoneNumber = model.PhoneNumber;
                    user.BirithDate = model.BirithDate;
                    user.UserName = model.UserName;
                }
                await _userManager.UpdateAsync(user);
                await _db.SaveChangesAsync();
                return user;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<Specialist> EditAdminUserInSpetialistRequestAsync(int SpetialistId, bool Accepted)
        {
            try
            {
                if (Accepted)
                {
                    var spetialist = await _db.Specialists.Include(x => x.User).FirstOrDefaultAsync(x => x.SpecialistId == SpetialistId);
                    if (spetialist != null)
                    {
                        spetialist.IsAccepted = true;
                        spetialist.User.Active = true;
                        var result = await _db.SaveChangesAsync();
                        if (result > 0)
                        {
                            return spetialist;
                        }
                        return null;
                    }
                    return null;
                }
                else
                {

                    var spetialist = await _db.Specialists.FindAsync(SpetialistId);
                    if (spetialist != null)
                    {
                        var user = await _userManager.FindByIdAsync(spetialist.UserId);
                        if (user != null)
                        {
                            _db.Users.Remove(user);
                            _db.Specialists.Remove(spetialist);
                            var result = await _db.SaveChangesAsync();
                            if (result > 0)
                            {
                                return null;
                            }
                        }
                        return null;
                    }
                    return null;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<Response<Specialist>> GetAdminUserAllSpetialistRequstAsync(int paggingNumber)
        {
            try
            {
                int AllPatientcount = await _db.Specialists.Where(x => x.IsAccepted == false).CountAsync();
                var AllPatient = await _db.Specialists.Where(x => x.IsAccepted == false).Skip((paggingNumber - 1) * 10).Take(10).ToListAsync();
                return new Response<Specialist>
                {
                    Success = true,
                    Message = "All Admins",
                    Data = AllPatient,
                    CountOfData = AllPatientcount,
                    paggingNumber = paggingNumber,
                    status_code = "200"
                };

            }
            catch (Exception e)
            {
                return new Response<Specialist>
                {
                    Success = false,
                    error = e.Message,
                    status_code = "500"
                };
            }
        }

        public async Task<ApplicationUser> GetAdminUserByIdAsync(string AdminUserId)
        {
            return await _userManager.FindByIdAsync(AdminUserId);

        }

        public async Task<List<ApplicationUser>> GetAdminUsersAsync()
        {
            return await _db.Users.ToListAsync();
        }

        public async Task<Response<ApplicationUser>> GetAllAdminAsync(int paggingNumber)
        {
            try
            {
                IList<ApplicationUser> admins = await _userManager.GetUsersInRoleAsync(Roles.Admin.ToString());
                int AllAdminCount = admins.Count();
                var AllAdmin = admins.Skip((paggingNumber - 1) * 10).Take(10);
                return new Response<ApplicationUser>
                {
                    Success = true,
                    Message = "All Admins",
                    Data = AllAdmin,
                    CountOfData = AllAdminCount,
                    paggingNumber = paggingNumber,
                    status_code = "200"
                };

            }
            catch (Exception e)
            {
                return new Response<ApplicationUser>
                {
                    Success = false,
                    error = e.Message,
                    status_code = "500"
                };
            }
        }

    }
}
