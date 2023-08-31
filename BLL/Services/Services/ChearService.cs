using BlL.Helper;
using BLL.Services.IServices;
using DAL.Enum;
using DAL.Models.Chear;
using DAL.Repository.IRepository;
using Microsoft.AspNetCore.Http;
using SpeakEase.DAL.Entities;
using SpeakEase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.Services
{
    public class ChearService : IChearService
    {
        #region Depend Injection
        private readonly IChearRepo _chearRepo;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ChearService(IChearRepo chearRepo, IHttpContextAccessor httpContextAccessor)
        {
            _chearRepo = chearRepo;
            _httpContextAccessor = httpContextAccessor;
        }
        #endregion

        #region Create
        public async Task<Response<Chear>> CreateChearAsync(ChearVM chear)
        {
            try
            {
                //var UploadFileAudo = UploadFileHelper.SaveFile(chear.Audio, "Chear/Audo");
                //var UploadFileImage = UploadFileHelper.SaveFile(chear.Image, "Chear/Image");

                Chear chear1 = new Chear();
                chear1.Word = chear.Word;
                chear1.Character = chear.Character;
                chear1.ChearPosition = chear.ChearPosition;
                chear1.IsDeleted = chear.IsDeleted;
                chear1.IsHiden = chear.IsHiden;
                if (chear.Audio is not null)
                {
                    var FileVedio = UploadFileHelper.SaveFile(chear.Audio, "Chear/Audio");
                    chear1.Audio = _httpContextAccessor.HttpContext.Request.Host.Value + "/Chear/Audio/" + FileVedio[0];

                    //var FileVedio = UploadFileHelper.SaveFile(chear.Audio, "Chear/Audo");
                    //chear1.Audio = _httpContextAccessor.HttpContext.Request.Host.Value + FileVedio[0];
                }
                if (chear.Image is not null)
                {
                    var FileVedio = UploadFileHelper.SaveFile(chear.Image, "Chear/Image");
                    chear1.Image = _httpContextAccessor.HttpContext.Request.Host.Value + "/Chear/Image/" + FileVedio[0];


                    //var FileVedio = UploadFileHelper.SaveFile(chear.Image, "Chear/Image");
                    //chear1.Image = _httpContextAccessor.HttpContext.Request.Host.Value + FileVedio[0];
                }
                var result = await _chearRepo.Create_ChearAsync(chear1);
                return result;

            }
            catch (Exception e)
            {
                return new Response<Chear>
                {
                    Success = false,
                    status_code = "500",
                    error = e.Message
                };
            }
        }
        #endregion

        #region Delete 
        public async Task<Response<Chear>> DeleteChearAsync(int ChearId)
        {
            try
            {
                var Chear = GetChearAsync(ChearId).Result.ObjectData;
                var result = await _chearRepo.Delete_ChearAsync(ChearId);
                return result;
            }
            catch (Exception e)
            {
                return new Response<Chear>
                {
                    Success = false,
                    status_code = "500",
                    error = e.Message
                };
            }
        }
        #endregion

        #region Get All
        public async Task<Response<Chear>> GetAllChearAsync(int Pagging)
        {
            try
            {
                var result = await _chearRepo.GetAll_ChearAsync(Pagging);
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
            catch (Exception e)
            {
                return new Response<Chear>
                {
                    Success = false,
                    status_code = "500",
                    error = e.Message
                };
            }
        }
        #endregion

        #region Get By Id
        public async Task<Response<Chear>> GetChearAsync(int ChearId)
        {
            try
            {
                var result = await _chearRepo.Get_ChearAsync(ChearId);
                if (result.ObjectData is not null)
                {
                    return new Response<Chear>
                    {
                        Success = true,
                        Message = "Chear Found",
                        ObjectData = result.ObjectData,
                        status_code = "200",

                    };
                }
                return new Response<Chear>
                {
                    Success = true,
                    Message = "Error",
                    ObjectData = null,
                    status_code = "404",

                };
            }
            catch (Exception e)
            {
                return new Response<Chear>
                {
                    Success = false,
                    status_code = "500",
                    error = e.Message
                };
            }
        }
        #endregion

        #region update
        public async Task<Response<Chear>> UpdateChearAsync(ChearEditVM chear)
        {
            try
            {
                //var UploadFileAudo = UploadFileHelper.SaveFile(chear.Audio, "Chear/Audo");
                //var UploadFileImage = UploadFileHelper.SaveFile(chear.Image, "Chear/Image");
                var oldChear = GetChearAsync(chear.ChearId).Result.ObjectData;
                if (oldChear is null)
                {
                    return new Response<Chear>
                    {
                        Success = false,
                        status_code = "404",

                        error = "Question is not Found"
                    };
                }
                if (chear.Audio is not null)
                {
                    var FileVedio = UploadFileHelper.SaveFile(chear.Audio, "Chear/Audio");
                    oldChear.Audio = _httpContextAccessor.HttpContext.Request.Host.Value + "/Chear/Audio/" + FileVedio[0];


                    //var FileVedio = UploadFileHelper.SaveFile(chear.Audio, "Chear/Audo");
                    //oldChear.Audio = _httpContextAccessor.HttpContext.Request.Host.Value + FileVedio[0];
                }
                if (chear.Image is not null)
                {
                    var FileVedio = UploadFileHelper.SaveFile(chear.Image, "Chear/Image");
                    oldChear.Image = _httpContextAccessor.HttpContext.Request.Host.Value + "/Chear/Image/" + FileVedio[0];

                    //var FileVedio = UploadFileHelper.SaveFile(chear.Image, "Chear/Image");
                    //oldChear.Image = _httpContextAccessor.HttpContext.Request.Host.Value + FileVedio[0];
                }
                oldChear.Word = chear.Word == null ? oldChear.Word : chear.Word;
                oldChear.IsHiden = chear.IsHiden == null ? oldChear.IsHiden : (bool)chear.IsHiden;
                oldChear.IsDeleted = chear.IsDeleted == null ? oldChear.IsDeleted : (bool)chear.IsDeleted;
                oldChear.Character = chear.Character == null ? oldChear.Character : (Character)chear.Character;
                oldChear.ChearPosition = chear.ChearPosition == null ? oldChear.ChearPosition : (ChearPosition)chear.ChearPosition;
                var resul = await _chearRepo.Update_ChearAsync(oldChear);
                return resul;
            }
            catch (Exception e)
            {
                return new Response<Chear>
                {
                    Success = false,
                    status_code = "500",
                    error = e.Message
                };
            }
        }
        #endregion
    }
}
