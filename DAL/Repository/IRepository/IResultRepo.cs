using SpeakEase.DAL.Entities;
using SpeakEase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository.IRepository
{
    public interface IResultRepo
    {
        Task<Response<Result>> Create_ResultAsync(Result result, string userId);
        Task<Response<Result>> Delete_ResultAsync(int Id, string userId);
        Task<Response<Result>> Get_ResultAsync(int Id);
        Task<Response<Result>> GetAll_ResultForPatientAsync(int patientId, int paggingNumber);
        Task<Response<Result>> GetAll_ResultForPatientOfSpetialistAsync(string userId, int paggingNumber);
        Task<Response<Result>> GetAll_ResultAsync(int paggingNumber);
        Task<Response<Result>> EditResultAsync(Result result, string userId);

    }
}
