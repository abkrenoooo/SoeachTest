using Bll.ExtensionMethods;
using BlL.Helper;
using BLL.Services.IServices;
using DAL.Models.SpecialistModel;
using DAL.Repository.IRepository;
using Microsoft.AspNetCore.Http;
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
        #region Depend Injection

        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ISpecialistRepo _specialistRepo;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public SpecialistServices(UserManager<ApplicationUser> UserManager, ISpecialistRepo specialistRepo, IHttpContextAccessor httpContextAccessor)
        {
            _userManager = UserManager;
            _specialistRepo = specialistRepo;
            _httpContextAccessor = httpContextAccessor;
        }
        #endregion

        #region Delete 

        public async Task<Response<SpecialistVM>> DeleteSpecialistAsync(int Id)
        {
            try
            {
                var spetialistvm = GetSpecialistAsync(Id).Result;

                if (!await _specialistRepo.DeleteSpecialistAsync(Id))
                {

                    return new Response<SpecialistVM>
                    {
                        Success = false,
                        Message = "error!",
                        status_code = "400",
                    };
                }
                if (spetialistvm is not null && spetialistvm.ObjectData != null && spetialistvm.ObjectData.ImageOfSpecializationCertificatePath is not null)
                {
                    var spetialist = spetialistvm.ObjectData.ToSpecialist().Result;
                    await _userManager.DeleteAsync(_userManager.FindByIdAsync(spetialist.UserId).Result);
                    var path = spetialist.ImageOfSpecializationCertificate.Replace(_httpContextAccessor.HttpContext.Request.Host.Value, "");
                    UploadFileHelper.RemoveFile(path);
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
        #endregion

        #region Depend Update

        public async Task<Response<SpecialistVM>> EditSpecialistAsync(SpecialistVMEdit specialist)
        {
            try
            {
                var data = await _specialistRepo.EditSpecialistAsync(specialist.ToSpecialistToSpecialistVMEdit().Result);

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
        #endregion

        #region get All

        public async Task<Response<SpecialistVM>> GetAllSpecialistAsync(int paggingNumber)
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
                return new Response<SpecialistVM>
                {
                    Success = result.Success,
                    Data = result.Data == null ? null : result.Data.ToList().ConvertAll(x => x.FromSpecialist().Result),
                    error = result.error,
                    Message = result.Message,
                    CountOfData = result.CountOfData,
                    paggingNumber = result.paggingNumber,
                    status_code = result.status_code,
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
        #endregion

        #region Get

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
        #endregion
    }
}
