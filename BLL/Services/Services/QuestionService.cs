using BlL.Helper;
using BLL.Services.IServices;
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
                chear1.IsDeleted = false;
                chear1.IsHidden =false;
                if (chear.Audio is not null)
                {
                    var FileVedio = UploadFileHelper.SaveFile(chear.Audio, "CharacterAudio");
                    chear1.Audio = _httpContextAccessor.HttpContext.Request.Host.Value + "/CharacterAudio/" + FileVedio[0];
                }
                if (chear.Image is not null)
                {
                    var FileVedio = UploadFileHelper.SaveFile(chear.Image, "CharacterImage");
                    chear1.Image = _httpContextAccessor.HttpContext.Request.Host.Value + "/CharacterImage/" + FileVedio[0];
                }
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

        #region Get All Not Hidden
        public async Task<Response<SpeakEase.DAL.Entities.Question>> GetAll_QuestionNotHiddenAsync(int Pagging)
        {
            try
            {
                var result = await _QuestionRepo.GetAll_QuestionNotHiddenAsync(Pagging);
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
                        Message = "Question Found",
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

        #region Get Last Question 
        public async Task<Response<SpeakEase.DAL.Entities.Question>> Get_LastQuestionAsync(int patient, string userId)
        {
            try
            {
                var result = await _QuestionRepo.Get_LastQuestionAsync( patient, userId);
                if (result.ObjectData is not null)
                {
                    return new Response<SpeakEase.DAL.Entities.Question>
                    {
                        Success = true,
                        Message = "Question Found",
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
                        Message = "Question Found",
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
                        Message = "Question Found",
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
        public async Task<Response<Question>> UpdateQuestionAsync(int Id, QuestionEditVM QuestionVM)
        {
            try
            {

                Question question = new Question();
                question.Word = QuestionVM.Word;
                question.Character = QuestionVM.Character;
                question.CharacterPosition = QuestionVM.ChearPosition;
                question.IsDeleted = QuestionVM.IsDeleted;
                question.IsHidden = QuestionVM.IsHidden;
                if (QuestionVM.Audio is not null)
                {
                    var FileVedio = UploadFileHelper.SaveFile(QuestionVM.Audio, "Question/Audio");
                    question.Audio = _httpContextAccessor.HttpContext.Request.Host.Value + "/Question/Audio/" + FileVedio[0];
                    
                }
                if (QuestionVM.Image is not null)
                {
                    var FileVedio = UploadFileHelper.SaveFile(QuestionVM.Image, "Question/Image");
                    question.Image = _httpContextAccessor.HttpContext.Request.Host.Value + "/Question/Image/" + FileVedio[0];
                }
                var result = await _QuestionRepo.Update_QuestionAsync(Id,question);
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

        #region Get All Question For Charecter
        public async Task<Response<Question>> Get_AllQuestionForCharacterAsync(Character QuestionId)
        {
            try
            {
                var result = await _QuestionRepo.Get_AllQuestionForCharacterAsync(QuestionId);
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
