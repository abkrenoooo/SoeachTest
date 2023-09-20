using DAL.Models.SpecialistModel;
using DAL.Repository.IRepository;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SpeakEase.DAL.Data;
using SpeakEase.DAL.Entities;
using SpeakEase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository.Repository
{
    public class SpecialistRepo : ISpecialistRepo
    {
        #region Depend Injection

        private readonly ApplicationDbContext _db;
        private readonly UserManager<ApplicationUser> _userManager;

        public SpecialistRepo(UserManager<ApplicationUser> UserManager, ApplicationDbContext db)
        {
            _db = db;
            _userManager = UserManager;
        }
        #endregion

        #region Delete 

        public async Task<bool> DeleteSpecialistAsync(int Id)
        {
            var specialist = await _db.Specialists.FindAsync(Id);
            if (specialist != null)
            {
                _db.Specialists.Remove(specialist);
                var result = await _db.SaveChangesAsync();
                return result > 0 ? true : false;
            }
            return false;
        }
        #endregion

        #region Get All 

        public async Task<Response<Specialist>> GetAllSpecialistAsync(int paggingNumber)
        {
            try
            {
                int AllPatientcount = await _db.Specialists.Where(x => x.IsAccepted == true).CountAsync();
                var AllPatient = await _db.Specialists.Include(x=>x.User).Where(x => x.IsAccepted == true).Skip((paggingNumber - 1) * 10).Take(10).ToListAsync();
                return new Response<Specialist>
                {
                    Success = true,
                    Message = "All Specialist",
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
        #endregion

        #region Get 

        public async Task<Specialist> GetSpecialistByIdAsync(int Id)
        {
            return await _db.Specialists.Include(x=>x.User).FirstOrDefaultAsync(x=>x.SpecialistId==Id);
        }
        #endregion

        #region Update

        public async Task<Specialist> EditSpecialistAsync(Specialist specialist)
        {
            try
            {
                var specialist01 = await _db.Specialists.Include(x => x.User).FirstOrDefaultAsync(x => x.SpecialistId == specialist.SpecialistId);
                specialist.User = await _userManager.FindByIdAsync(specialist01.UserId);
                if (specialist != null && specialist01 != null&& specialist.User!=null)
                {
                    specialist01.Hospital = specialist.Hospital == null ? specialist01.Hospital : specialist.Hospital; 
                    specialist01.City = specialist.City == null ? specialist01.City : specialist.City; 
                    specialist01.Country = specialist.Country == null ? specialist01.Country : specialist.Country;
                    specialist01.IdNumber = specialist.IdNumber == null ? specialist01.IdNumber : specialist.IdNumber; 
                    specialist01.User.FirstName = specialist.User.FirstName == null ? specialist01.User.FirstName : specialist.User.FirstName; ;
                    specialist01.User.LastName = specialist.User.LastName == null ? specialist01.User.LastName : specialist.User.LastName; ;
                    specialist01.User.SecondName = specialist.User.SecondName == null ? specialist01.User.SecondName : specialist.User.SecondName; ;
                    specialist01.User.BirithDate = specialist.User.BirithDate == null ? specialist01.User.BirithDate : specialist.User.BirithDate; ;
                    specialist01.User.Gender = specialist.User.Gender == null ? specialist01.User.Gender : specialist.User.Gender; ;
                    specialist01.User.UserName = specialist.User.UserName == null ? specialist01.User.UserName : specialist.User.UserName; ;
                    specialist01.User.Email = specialist.User.Email == null ? specialist01.User.Email : specialist.User.Email; ;
                    specialist01.User.PhoneNumber = specialist.User.PhoneNumber == null ? specialist01.User.PhoneNumber : specialist.User.PhoneNumber;
                    _db.Specialists.Update(specialist01);        
                    var result = await _db.SaveChangesAsync();
                    if (result > 0)
                    {
                        return specialist01;
                    }
                    return null;
                }
                return null;
            }
            catch (Exception)
            {
                return null;
            }

        }
        #endregion

    }
}
