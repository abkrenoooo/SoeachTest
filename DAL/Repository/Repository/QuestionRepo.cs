using DAL.Enum;
using DAL.Repository.IRepository;
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
    public class QuestionRepo : IQuestionRepo
    {
        #region Depend Injection

        private readonly ApplicationDbContext db;

        public QuestionRepo(ApplicationDbContext db)
        {
            this.db = db;
        }
        #endregion

        #region Create

        public async Task<Response<Question>> Create_QuestionAsync(Question chear)
        {
            try
            {
                var chearsCount = await db.Questions.Where(x => x.Character == chear.Character && x.CharacterPosition == chear.CharacterPosition && x.IsDeleted == false).CountAsync();
                if (chearsCount == 0)
                {
                    await db.Questions.AddAsync(chear);
                    await db.SaveChangesAsync();
                    return new Response<Question>
                    {
                        Success = true,
                        Message = " Question is Created",
                        status_code = "200",
                        ObjectData = chear
                    };
                }
                return new Response<Question>
                {
                    Success = true,
                    Message = "Qustion With the same Character and Character Position is found before",
                    status_code = "500",
                };
            }
            catch (Exception e)
            {
                return new Response<Question>
                {
                    Success = true,
                    error = e.Message,
                    status_code = "500"
                };
            }
        }
        #endregion

        #region Delete
        public async Task<Response<Question>> Delete_QuestionAsync(int ChearId)
        {
            try
            {
                var chear = await db.Questions.Where(n => !n.IsDeleted && n.ChearId == ChearId).SingleOrDefaultAsync();

                if (chear == null)
                {

                    return new Response<Question>
                    {
                        Success = true,
                        Message = "Question Not Found",
                        status_code = "404"
                    };
                }
                chear.IsDeleted = true;
                chear.IsHiden = true;
                //var result = Update_QuestionAsync(chear);

                //db.Chears.Remove(chear);
                await db.SaveChangesAsync();
                return new Response<Question>
                {
                    Success = true,
                    Message = "Question Is Deleted",
                    status_code = "200",
                };
            }
            catch (Exception e)
            {
                return new Response<Question>
                {
                    Success = true,
                    error = e.Message,
                    status_code = "500"
                };
            }
        }
        #endregion

        #region Get All
        public async Task<Response<Question>> GetAll_QuestionAsync(int Pagging)
        {
            try
            {
                int AllChearCount = await db.Questions.Where(n => !n.IsDeleted).CountAsync();
                var AllChear = await db.Questions.Skip((Pagging - 1) * 10).Take(10).

                    ToListAsync();
                return new Response<Question>
                {
                    Success = true,
                    status_code = "200",
                    Data = AllChear,
                    CountOfData = AllChearCount,
                    Message = "All Questions"
                };
            }
            catch (Exception e)
            {
                return new Response<Question>
                {
                    Success = true,
                    error = e.Message,
                    status_code = "500"
                };
            }
        }
        #endregion

        #region Get
        public async Task<Response<Question>> Get_QuestionAsync(int ChearId)
        {
            try
            {
                var chear = await db.Questions.Where(n => !n.IsDeleted && n.ChearId == ChearId).SingleOrDefaultAsync();
                if (chear == null)
                {
                    return new Response<Question>
                    {
                        Success = true,
                        Message = "Question Not Found",
                        status_code = "200"
                    };
                }
                return new Response<Question>
                {
                    Success = true,
                    Message = "Question Found",
                    status_code = "200",
                    ObjectData = chear
                };
            }
            catch (Exception e)
            {
                return new Response<Question>
                {
                    Success = true,
                    error = e.Message,
                    status_code = "500"
                };
            }
        }
        #endregion

        #region Get Secound Question
        public async Task<Response<Question>> Get_SecoundQuestionAsync(int ChearId)
        {
            try
            {
                var chear = await db.Questions.Where(n => !n.IsDeleted && n.ChearId == ChearId).SingleOrDefaultAsync();

                if (chear == null)
                {
                    return new Response<Question>
                    {
                        Success = true,
                        Message = "Question Not Found",
                        status_code = "200"
                    };
                }
                //if pass Initial State of Character
                if (chear.CharacterPosition == CharacterPosition.InitialFirst || chear.CharacterPosition == CharacterPosition.InitialSecond)
                {
                    var SecoundChear = await db.Questions.Where(n => !n.IsDeleted && n.Character == chear.Character && n.CharacterPosition == CharacterPosition.MiddleFirst).SingleOrDefaultAsync();
                    if (SecoundChear == null)
                    {
                        return new Response<Question>
                        {
                            Success = true,
                            Message = "Question Not Found",
                            status_code = "404",
                        };
                    }
                    return new Response<Question>
                    {
                        Success = true,
                        Message = "Question Found",
                        status_code = "200",
                        ObjectData = SecoundChear
                    };
                }
                //if pass Middle State of Character
                if (chear.CharacterPosition == CharacterPosition.MiddleFirst || chear.CharacterPosition == CharacterPosition.MiddleSecond)
                {
                    var SecoundChear = await db.Questions.Where(n => !n.IsDeleted && n.Character == chear.Character && n.CharacterPosition == CharacterPosition.FinalFirst).SingleOrDefaultAsync();
                    if (SecoundChear == null)
                    {
                        return new Response<Question>
                        {
                            Success = true,
                            Message = "Question Not Found",
                            status_code = "404",
                        };
                    }
                    return new Response<Question>
                    {
                        Success = true,
                        Message = "Question Found",
                        status_code = "200",
                        ObjectData = SecoundChear
                    };
                }
                //if pass Final State of Character

                var secoundChear = await db.Questions.Where(n => !n.IsDeleted && n.Character == (Character)(chear.Character + 1) && n.CharacterPosition == CharacterPosition.InitialFirst).SingleOrDefaultAsync();
                if (secoundChear == null)
                {
                    return new Response<Question>
                    {
                        Success = true,
                        Message = "Question Not Found",
                        status_code = "404",
                    };
                }
                return new Response<Question>
                {
                    Success = true,
                    Message = "Question Found",
                    status_code = "200",
                    ObjectData = secoundChear
                };

            }
            catch (Exception e)
            {
                return new Response<Question>
                {
                    Success = true,
                    error = e.Message,
                    status_code = "500"
                };
            }
        }
        #endregion

        #region Get Replace Question
        public async Task<Response<Question>> Get_ReplaceQuestionAsync(int ChearId)
        {
            try
            {
                var chear = await db.Questions.Where(n => !n.IsDeleted && n.ChearId == ChearId).SingleOrDefaultAsync();
                if (chear == null)
                {
                    return new Response<Question>
                    {
                        Success = true,
                        Message = "Question Not Found",
                        status_code = "200"
                    };
                }
                else if (chear.CharacterPosition == CharacterPosition.InitialFirst)
                {
                    var ReplaceChear = await db.Questions.Where(n => !n.IsDeleted && n.Character == chear.Character && n.CharacterPosition == CharacterPosition.InitialSecond).SingleOrDefaultAsync();
                    return new Response<Question>
                    {
                        Success = true,
                        Message = "Question Found",
                        status_code = "200",
                        ObjectData = ReplaceChear
                    };
                }
                else if (chear.CharacterPosition == CharacterPosition.InitialSecond)
                {
                    var ReplaceChear = await db.Questions.Where(n => !n.IsDeleted && n.Character == chear.Character && n.CharacterPosition == CharacterPosition.InitialFirst).SingleOrDefaultAsync();
                    return new Response<Question>
                    {
                        Success = true,
                        Message = "Question Found",
                        status_code = "200",
                        ObjectData = ReplaceChear
                    };
                }
                else if (chear.CharacterPosition == CharacterPosition.MiddleFirst)
                {
                    var ReplaceChear = await db.Questions.Where(n => !n.IsDeleted && n.Character == chear.Character && n.CharacterPosition == CharacterPosition.MiddleSecond).SingleOrDefaultAsync();
                    return new Response<Question>
                    {
                        Success = true,
                        Message = "Question Found",
                        status_code = "200",
                        ObjectData = ReplaceChear
                    };
                }
                else if (chear.CharacterPosition == CharacterPosition.MiddleSecond )
                {
                    var ReplaceChear = await db.Questions.Where(n => !n.IsDeleted && n.Character == chear.Character && n.CharacterPosition == CharacterPosition.MiddleFirst).SingleOrDefaultAsync();
                    return new Response<Question>
                    {
                        Success = true,
                        Message = "Question Found",
                        status_code = "200",
                        ObjectData = ReplaceChear
                    };
                }
                else if (chear.CharacterPosition == CharacterPosition.FinalFirst )
                {
                    var ReplaceChear = await db.Questions.Where(n => !n.IsDeleted && n.Character == chear.Character && n.CharacterPosition == CharacterPosition.FinalSecond).SingleOrDefaultAsync();
                    return new Response<Question>
                    {
                        Success = true,
                        Message = "Question Found",
                        status_code = "200",
                        ObjectData = ReplaceChear
                    };
                }
                else
                {
                    var ReplaceChear = await db.Questions.Where(n => !n.IsDeleted && n.Character == chear.Character && n.CharacterPosition == CharacterPosition.FinalFirst).SingleOrDefaultAsync();
                    return new Response<Question>
                    {
                        Success = true,
                        Message = "Question Found",
                        status_code = "200",
                        ObjectData = ReplaceChear
                    };
                }

            }
            catch (Exception e)
            {
                return new Response<Question>
                {
                    Success = true,
                    error = e.Message,
                    status_code = "500"
                };
            }
        }
        #endregion

        #region Ubdate

        public async Task<Response<Question>> Update_QuestionAsync(Question chear2)
        {
            try
            {
                var chear = await db.Questions.Where(n => !n.IsDeleted && n.ChearId == chear2.ChearId).SingleOrDefaultAsync();
                if (chear == null)
                {
                    return new Response<Question>
                    {
                        Success = true,
                        ObjectData = chear,
                        Message = "Question Not Found",
                        status_code = "404"
                    };
                }
                var chearsCount = await db.Questions.Where(x => x.ChearId != chear.ChearId && x.Character == chear.Character && x.CharacterPosition == chear.CharacterPosition && x.IsDeleted == false).CountAsync();
                if (chearsCount != 0)
                {
                    return new Response<Question>
                    {
                        Success = true,
                        Message = "Qustion With the same Character and Character Position is found before",
                        status_code = "500",
                    };
                }
                chear.Audio = chear2.Audio;
                chear.Word = chear2.Word;
                chear.Image = chear2.Image;
                chear.CharacterPosition = chear2.CharacterPosition;
                chear.Character = chear2.Character;
                chear.IsHiden = chear2.IsHiden;
                chear.IsDeleted = chear2.IsDeleted;

                await db.SaveChangesAsync();

                return new Response<Question>
                {
                    Success = true,
                    ObjectData = chear,
                    Message = "Question is Udpeted",
                    status_code = "200"
                };
            }
            catch (Exception e)
            {
                return new Response<Question>
                {
                    Success = true,
                    error = e.Message,
                    status_code = "500"
                };
            }
        }
        #endregion
    }
}
