using Bll.ExtensionMethods;
using BLL.Services.IServices;
using DAL.Models.SpecialistModel;
using DAL.Repository.IRepository;
using Microsoft.AspNetCore.Identity;
using SpeakEase.DAL.Entities;
using SpeakEase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.Services
{
    public class SpecialistServices : ISpecialistServices
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ISpecialistRepo _specialistRepo;

        public SpecialistServices(UserManager<ApplicationUser> UserManager, ISpecialistRepo specialistRepo)
        {
            _userManager = UserManager;
            _specialistRepo = specialistRepo;
        }
        public async Task<Response<SpecialistVM>> DeleteSpecialistAsync(int Id)
        {
            try
            {
                if (!await _specialistRepo.DeleteSpecialistAsync(Id))
                {
                    return new Response<SpecialistVM>
                    {
                        Success = false,
                        Message = "error!",
                        status_code = "400",
                    };
                }
                return new Response<SpecialistVM>
                {
                    Success = true,
                    Message = "Specialist has removed",
                    status_code = "200",
                };
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

        public async Task<Response<SpecialistVM>> EditSpecialistAsync(SpecialistVM specialist)
        {
            try
            {
                var data = await _specialistRepo.EditSpecialistAsync(specialist.ToSpecialist().Result);

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
                    ObjectData = specialist,
                    Success = true,
                    Message = "Spetialist  is Updated",
                    status_code = "200",
                };
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

        public async Task<Response<Specialist>> GetAllSpecialistAsync(int paggingNumber)
        {
            try
            {
                var result = await _specialistRepo.GetAllSpecialistAsync(paggingNumber);

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

        public async Task<Response<SpecialistVM>> GetSpecialistAsync(int Id)
        {
            try
            {
                var data = await _specialistRepo.GetSpecialistByIdAsync(Id);
                if (data == null)
                {
                    return new Response<SpecialistVM>
                    {
                        Success = false,
                        Message = "Error",
                        status_code = "404",
                    };
                }
                return new Response<SpecialistVM>
                {
                    Success = true,
                    ObjectData = await data.FromSpecialist(),
                    Message = "Data Found",
                    status_code = "200",
                };
            }
            catch (Exception ex)
            {
                return new Response<SpecialistVM>
                {
                    Success = true,
                    Message = ex.Message,
                    status_code = "400",
                };
            }
        }
    }
}
