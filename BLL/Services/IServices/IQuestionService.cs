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
        Task<Response<Question>> CreateQuestionAsync(QuestionVM chear);
        Task<Response<Question>> DeleteQuestionAsync(int ChearId);
        Task<Response<Question>> GetAllQuestionAsync(int Pagging);
        Task<Response<Question>> GetQuestionAsync(int ChearId);
        Task<Response<Question>> GetSecoundQuestionAsync(int ChearId);
        Task<Response<Question>> GetReplaceQuestionAsync(int ChearId);
        Task<Response<Question>> UpdateQuestionAsync(QuestionEditVM chear);
        Task<Response<Question>> GetAllQuestionChearAsync(Character ChearId);

    }
}
