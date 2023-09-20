using BLL.Services.IServices;
using DAL.Models.Result;
using DAL.Repository.IRepository;
using SpeakEase.DAL.Entities;
using SpeakEase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.Services
{
    public class ResultServices : IResultServices
    {
        #region Depend Injection

        private readonly IResultRepo _resultRepo;

        public ResultServices(IResultRepo resultRepo)
        {
            _resultRepo = resultRepo;
        }
        #endregion

        #region Create
        public async Task<Response<Result>> Create_ResultAsync(ResultVM result, string userId)
        {
            Result result1 = new Result()
            {
                AnotherCharacter = result.AnotherCharacter,
                QuestionId = result.QuestionId,
                ChearState = result.ChearState,
                PatientId = result.PatientId,
                SpecialistId = result.PatientId,
                IsDeleted = false,
                ChearPositionResult = result.ChearPositionResult,
            };
            var result01 = await _resultRepo.Create_ResultAsync(result1, userId);

            return result01;
        }
        #endregion

        #region Delete
        public async Task<Response<Result>> Delete_ResultAsync(int Id, string userId)
        {
            var result01 = await _resultRepo.Delete_ResultAsync(Id, userId);

            return result01;
        }
        #endregion

        #region Update
        public async Task<Response<Result>> EditResultAsync(ResultVM result, string userId)
        {
            Result result1 = new Result()
            {
                AnotherCharacter = result.AnotherCharacter,
                QuestionId = result.QuestionId,
                ChearState = result.ChearState,
                PatientId = result.PatientId,
                SpecialistId = result.PatientId,
                IsDeleted = false,
                ChearPositionResult = result.ChearPositionResult,
            };
            var result01 = await _resultRepo.EditResultAsync(result1, userId);

            return result01;
        }
        #endregion

        #region Get All
        public async Task<Response<Result>> GetAll_ResultAsync(int paggingNumber)
        {
            var result01 = await _resultRepo.GetAll_ResultAsync(paggingNumber);

            return result01;
        }
        #endregion

        #region Get All Result For Patient
        public async Task<Response<Result>> GetAll_ResultForPatientAsync(int patientId, int paggingNumber)
        {
            var result01 = await _resultRepo.GetAll_ResultForPatientAsync(patientId, paggingNumber);

            return result01;
        }
        #endregion

        #region Get All Result For Patients For Sprtialist

        public async Task<Response<Result>> GetAll_ResultForPatientOfSpetialistAsync(string userId, int paggingNumber)
        {
            var result01 = await _resultRepo.GetAll_ResultForPatientOfSpetialistAsync(userId, paggingNumber);

            return result01;
        }
        #endregion

        #region Get 
        public async Task<Response<Result>> Get_ResultAsync(int Id)
        {
            var result01 = await _resultRepo.Get_ResultAsync(Id);

            return result01;
        }
        #endregion

    }
}
