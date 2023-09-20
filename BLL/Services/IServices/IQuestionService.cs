using DAL.Enum;
using DAL.Models.Question;
using SpeakEase.DAL.Entities;
using SpeakEase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.IServices
{
    public interface IQuestionService
    {
        Task<Response<Question>> CreateQuestionAsync(QuestionVM question);
        Task<Response<Question>> DeleteQuestionAsync(int questionId);
        Task<Response<Question>> GetAllQuestionAsync(int Pagging);
        Task<Response<Question>> GetQuestionAsync(int questionId); 
        Task<Response<Question>> Get_LastQuestionAsync(int patient, string userId);
        Task<Response<Question>> GetSecoundQuestionAsync(int questionId);
        Task<Response<Question>> GetReplaceQuestionAsync(int questionId);
        Task<Response<Question>> UpdateQuestionAsync(int Id,QuestionVM question);
        Task<Response<Question>> Get_AllQuestionForCharacterAsync(Character questionId);

    }
}
