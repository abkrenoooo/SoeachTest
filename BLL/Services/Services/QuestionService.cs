using BlL.Helper;
using BLL.Services.IServices;
using DAL.Entities;
using DAL.Enum;
using DAL.Models.Question;
using DAL.Repository.IRepository;
using Microsoft.AspNetCore.Http;
using SpeakEase.DAL.Data;
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
    public class QuestionService : IQuestionService
    {
        #region Depend Injection
        private readonly IQuestionRepo _QuestionRepo;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ApplicationDbContext db;

        public QuestionService(IQuestionRepo QuestionRepo, IHttpContextAccessor httpContextAccessor, ApplicationDbContext db)
        {
            _QuestionRepo = QuestionRepo;
            _httpContextAccessor = httpContextAccessor;
            this.db = db;
        }
        #endregion

        #region Create
        public async Task<Response<SpeakEase.DAL.Entities.Question>> CreateQuestionAsync(QuestionVM chear)
        {
            try
            {
                SpeakEase.DAL.Entities.Question chear1 = new SpeakEase.DAL.Entities.Question();
                chear1.Word = chear.Word;
                chear1.Character = chear.Character;
                chear1.CharacterPosition = chear.ChearPosition;
                chear1.IsDeleted = chear.IsDeleted;
                chear1.IsHiden = chear.IsHiden;
                List<files> files = new List<files>();
                if (chear.Audio is not null)
                {
                    var fileAudio = await UploadFileHelper.UploadFile(chear.Audio);
                    await db.Files.AddAsync(fileAudio);
                    await db.SaveChangesAsync();
                    files.Add(fileAudio);

                    //var FileVedio = UploadFileHelper.SaveFile(chear.Audio, "Chear/Audio");
                    //chear1.Audio = _httpContextAccessor.HttpContext.Request.Host.Value + "/Chear/Audio/" + FileVedio[0];
                    //var fileAudio = await UploadFileHelper.UploadFile(chear.Audio);
                    //chear1.Audio = fileAudio;
                }
                if (chear.Image is not null)
                {
                    var fileImage = await UploadFileHelper.UploadFile(chear.Image);
                    await db.Files.AddAsync(fileImage);
                    await db.SaveChangesAsync();
                    files.Add(fileImage);
                    //var FileVedio = UploadFileHelper.SaveFile(chear.Image, "Chear/Image");
                    //chear1.Image = _httpContextAccessor.HttpContext.Request.Host.Value + "/Chear/Image/" + FileVedio[0];
                }
                chear1.files = files;
                var result = await _QuestionRepo.Create_QuestionAsync(chear1);
                return result;

            }
            catch (Exception e)
            {
                return new Response<SpeakEase.DAL.Entities.Question>
                {
                    Success = false,
                    status_code = "500",
                    error = e.Message
                };
            }
        }
        #endregion

        #region Delete 
        public async Task<Response<SpeakEase.DAL.Entities.Question>> DeleteQuestionAsync(int ChearId)
        {
            try
            {
                var Chear = GetQuestionAsync(ChearId).Result.ObjectData;
                var result = await _QuestionRepo.Delete_QuestionAsync(ChearId);
                return result;
            }
            catch (Exception e)
            {
                return new Response<SpeakEase.DAL.Entities.Question>
                {
                    Success = false,
                    status_code = "500",
                    error = e.Message
                };
            }
        }
        #endregion

        #region Get All
        public async Task<Response<SpeakEase.DAL.Entities.Question>> GetAllQuestionAsync(int Pagging)
        {
            try
            {
                var result = await _QuestionRepo.GetAll_QuestionAsync(Pagging);
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
                return new Response<SpeakEase.DAL.Entities.Question>
                {
                    Success = false,
                    status_code = "500",
                    error = e.Message
                };
            }
        }
        #endregion

        #region Get By Id
        public async Task<Response<SpeakEase.DAL.Entities.Question>> GetQuestionAsync(int ChearId)
        {
            try
            {
                var result = await _QuestionRepo.Get_QuestionAsync(ChearId);
                if (result.ObjectData is not null)
                {
                    return new Response<SpeakEase.DAL.Entities.Question>
                    {
                        Success = true,
                        Message = "Chear Found",
                        ObjectData = result.ObjectData,
                        status_code = "200",

                    };
                }
                return new Response<SpeakEase.DAL.Entities.Question>
                {
                    Success = true,
                    Message = "Error",
                    ObjectData = null,
                    status_code = "404",

                };
            }
            catch (Exception e)
            {
                return new Response<SpeakEase.DAL.Entities.Question>
                {
                    Success = false,
                    status_code = "500",
                    error = e.Message
                };
            }
        }
        #endregion

        #region Get Secound Question
        public async Task<Response<SpeakEase.DAL.Entities.Question>> GetSecoundQuestionAsync(int ChearId)
        {
            try
            {
                var result = await _QuestionRepo.Get_SecoundQuestionAsync(ChearId);
                if (result.ObjectData is not null)
                {
                    return new Response<SpeakEase.DAL.Entities.Question>
                    {
                        Success = true,
                        Message = "Chear Found",
                        ObjectData = result.ObjectData,
                        status_code = "200",

                    };
                }
                return new Response<SpeakEase.DAL.Entities.Question>
                {
                    Success = true,
                    Message = "Error",
                    ObjectData = null,
                    status_code = "404",

                };
            }
            catch (Exception e)
            {
                return new Response<SpeakEase.DAL.Entities.Question>
                {
                    Success = false,
                    status_code = "500",
                    error = e.Message
                };
            }
        }
        #endregion

        #region Get Replace Question
        public async Task<Response<SpeakEase.DAL.Entities.Question>> GetReplaceQuestionAsync(int ChearId)
        {
            try
            {
                var result = await _QuestionRepo.Get_ReplaceQuestionAsync(ChearId);
                if (result.ObjectData is not null)
                {
                    return new Response<SpeakEase.DAL.Entities.Question>
                    {
                        Success = true,
                        Message = "Chear Found",
                        ObjectData = result.ObjectData,
                        status_code = "200",

                    };
                }
                return new Response<SpeakEase.DAL.Entities.Question>
                {
                    Success = true,
                    Message = "Error",
                    ObjectData = null,
                    status_code = "404",

                };
            }
            catch (Exception e)
            {
                return new Response<SpeakEase.DAL.Entities.Question>
                {
                    Success = false,
                    status_code = "500",
                    error = e.Message
                };
            }
        }
        #endregion

        #region update
        public async Task<Response<SpeakEase.DAL.Entities.Question>> UpdateQuestionAsync(QuestionEditVM chear)
        {
            try
            {
                
                var oldChear = GetQuestionAsync(chear.ChearId).Result.ObjectData;
                if (oldChear is null)
                {
                    return new Response<SpeakEase.DAL.Entities.Question>
                    {
                        Success = false,
                        status_code = "404",

                        error = "Question is not Found"
                    };
                }
                if (chear.Audio is not null)
                {
                    //var FileVedio = UploadFileHelper.SaveFile(chear.Audio, "Chear/Audio");
                    //oldChear.Audio = _httpContextAccessor.HttpContext.Request.Host.Value + "/Chear/Audio/" + FileVedio[0];


                    //var FileVedio = UploadFileHelper.SaveFile(chear.Audio, "Chear/Audo");
                    //oldChear.Audio = _httpContextAccessor.HttpContext.Request.Host.Value + FileVedio[0];
                }
                if (chear.Image is not null)
                {
                    //var FileVedio = UploadFileHelper.SaveFile(chear.Image, "Chear/Image");
                    //oldChear.Image = _httpContextAccessor.HttpContext.Request.Host.Value + "/Chear/Image/" + FileVedio[0];

                    //var FileVedio = UploadFileHelper.SaveFile(chear.Image, "Chear/Image");
                    //oldChear.Image = _httpContextAccessor.HttpContext.Request.Host.Value + FileVedio[0];
                }
                oldChear.Word = chear.Word == null ? oldChear.Word : chear.Word;
                oldChear.IsHiden = chear.IsHiden == null ? oldChear.IsHiden : (bool)chear.IsHiden;
                oldChear.IsDeleted = chear.IsDeleted == null ? oldChear.IsDeleted : (bool)chear.IsDeleted;
                oldChear.Character = chear.Character == null ? oldChear.Character : (DAL.Enum.Character)chear.Character;
                oldChear.CharacterPosition = chear.ChearPosition == null ? oldChear.CharacterPosition : (CharacterPosition)chear.ChearPosition;
                var resul = await _QuestionRepo.Update_QuestionAsync(oldChear);
                return resul;
            }
            catch (Exception e)
            {
                return new Response<SpeakEase.DAL.Entities.Question>
                {
                    Success = false,
                    status_code = "500",
                    error = e.Message
                };
            }
        }


        #endregion
        #region GetChearQuction
        public async Task<Response<Question>> GetAllQuestionChearAsync(Character ChearId)
        {
            try
            {
                var result = await _QuestionRepo.GetAll_QuestionChearAsync(ChearId);
                return result;

            }
            catch (Exception e)
            {
                return new Response<SpeakEase.DAL.Entities.Question>
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
