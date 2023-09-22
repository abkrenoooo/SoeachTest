using DAL.Enum;
using SpeakEase.DAL.Entities;
using SpeakEase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository.IRepository
{
    public interface IQuestionRepo
    {
        Task<Response<Question>> Create_QuestionAsync(Question chear);
        Task<Response<Question>> Delete_QuestionAsync(int ChearId);
        Task<Response<Question>> GetAll_QuestionAsync(int Pagging);
        Task<Response<Question>> GetAll_QuestionNotHiddenAsync(int Pagging);
        Task<Response<Question>> Get_QuestionAsync(int ChearId);
        Task<Response<Question>> Get_LastQuestionAsync(int patient,string userId);
        Task<Response<Question>> Get_SecoundQuestionAsync(int ChearId);
        Task<Response<Question>> Get_ReplaceQuestionAsync(int ChearId);
        Task<Response<Question>> Update_QuestionAsync(int Id,Question chear);
        Task<Response<Question>> Get_AllQuestionForCharacterAsync(Character ChearId);

    }
}
