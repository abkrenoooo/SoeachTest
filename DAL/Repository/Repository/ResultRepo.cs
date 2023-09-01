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
    public class ResultRepo : IResultRepo
    {
        #region Depend Injection

        private readonly ApplicationDbContext _db;

        public ResultRepo(ApplicationDbContext db)
        {
            _db = db;
        }
        #endregion

        #region Create
        public async Task<Response<Result>> Create_ResultAsync(Result result, string userId)
        {
            try
            {
                var specialist = await _db.Specialists.FirstOrDefaultAsync(x => x.UserId == userId);

                if (specialist == null)
                {
                    return new Response<Result>
                    {
                        Success = true,
                        Message = "Specialist not correct",
                        status_code = "404"
                    };
                }
                var results = await _db.Results.Where(x => x.PatientId == result.PatientId).CountAsync();
                if (results == 0)
                {
                    var patient = await _db.Patients.FirstOrDefaultAsync(x => x.PatientId == result.PatientId);
                    if (patient != null)
                    {
                        patient.StartDate = DateTime.Now;
                    }
                }
                _db.Entry(result).Property(p => p.SpecialistId).IsModified = true;
                result.SpecialistId = specialist.SpecialistId;
                await _db.Results.AddAsync(result);
                await _db.SaveChangesAsync();

                return new Response<Result>
                {
                    Success = true,
                    ObjectData = result,
                    Message = "Created the result",
                    status_code = "200"
                };
            }
            catch (Exception e)
            {
                return new Response<Result>
                {
                    Success = false,
                    error = e.Message,
                    status_code = "500"
                };
            }
        }
        #endregion

        #region Delete
        public async Task<Response<Result>> Delete_ResultAsync(int Id, string userId)
        {
            try
            {
                var Result = await _db.Results.Where(n => !n.IsDeleted && n.ResultId == Id).SingleOrDefaultAsync();

                if (Result == null)
                {

                    return new Response<Result>
                    {
                        Success = true,
                        Message = "Result Not Found",
                        status_code = "404"
                    };
                }
                Result.IsDeleted = true;
                var result =EditResultAsync(Result, userId);

                await _db.SaveChangesAsync();
                return new Response<Result>
                {
                    Success = true,
                    Message = "Result Is Deleted",
                    status_code = "200",
                };
            }
            catch (Exception e)
            {
                return new Response<Result>
                {
                    Success = true,
                    error = e.Message,
                    status_code = "500"
                };
            }
        }
        #endregion

        #region Update
        public async Task<Response<Result>> EditResultAsync(Result result, string userId)
        {
            try
            {
                var specialist = await _db.Specialists.FirstOrDefaultAsync(x => x.UserId == userId);

                if (specialist == null)
                {
                    return new Response<Result>
                    {
                        Success = true,
                        Message = "SpecialistId not correct",
                        status_code = "404"
                    };
                }
                var oldresult = await _db.Results.FirstOrDefaultAsync(x => x.ResultId == result.ResultId);
                _db.Entry(result).Property(p => p.SpecialistId).IsModified = true;
                oldresult.SpecialistId = specialist.SpecialistId;
                oldresult.ChearState = result.ChearState;
                oldresult.ChearPositionResult = result.ChearPositionResult;
                oldresult.AnotherCharacter = result.AnotherCharacter;
                _db.Results.Update(oldresult);
                await _db.SaveChangesAsync();

                return new Response<Result>
                {
                    Success = true,
                    ObjectData = oldresult,
                    Message = "Created the result",
                    status_code = "200"
                };
            }
            catch (Exception e)
            {
                return new Response<Result>
                {
                    Success = false,
                    error = e.Message,
                    status_code = "500"
                };
            }
        }
        #endregion

        #region Get All
        public async Task<Response<Result>> GetAll_ResultAsync(int paggingNumber)
        {
            try
            {
                int AllPatientcount = await _db.Results.CountAsync();
                var AllPatient = await _db.Results.Skip((paggingNumber - 1) * 10).Take(10).ToListAsync(); ;
                return new Response<Result>
                {
                    Success = true,
                    Message = "All Results",
                    Data = AllPatient,
                    CountOfData = AllPatientcount,
                    paggingNumber = paggingNumber,
                    status_code = "200"
                };

            }
            catch (Exception e)
            {
                return new Response<Result>
                {
                    Success = false,
                    error = e.Message,
                    status_code = "500"
                };
            }
        }
        #endregion

        #region Get All Result For Patient
        public async Task<Response<Result>> GetAll_ResultForPatientAsync(int patientId, int paggingNumber)
        {
            try
            {
                int AllPatientcount = await _db.Results.Where(x => x.PatientId == patientId).CountAsync();
                var AllPatient = await _db.Results.Where(x => x.PatientId == patientId).Skip((paggingNumber - 1) * 10).Take(10).ToListAsync(); ;
                return new Response<Result>
                {
                    Success = true,
                    Message = "All Results",
                    Data = AllPatient,
                    CountOfData = AllPatientcount,
                    paggingNumber = paggingNumber,
                    status_code = "200"
                };

            }
            catch (Exception e)
            {
                return new Response<Result>
                {
                    Success = false,
                    error = e.Message,
                    status_code = "500"
                };
            }
        }
        #endregion

        #region Get All Result For Patients For Sprtialist

        public async Task<Response<Result>> GetAll_ResultForPatientOfSpetialistAsync(string userId, int paggingNumber)
        {
            try
            {
                var specialist = await _db.Specialists.FirstOrDefaultAsync(x => x.UserId == userId);

                if (specialist == null)
                {
                    return new Response<Result>
                    {
                        Success = true,
                        Message = "SpecialistId not correct",
                        status_code = "404"
                    };
                }
                int AllPatientcount = await _db.Results.Where(x => x.SpecialistId == specialist.SpecialistId).CountAsync();
                var AllPatient = await _db.Results.Where(x => x.SpecialistId == specialist.SpecialistId).Skip((paggingNumber - 1) * 10).Take(10).ToListAsync(); ;
                return new Response<Result>
                {
                    Success = true,
                    Message = "All Results",
                    Data = AllPatient,
                    CountOfData = AllPatientcount,
                    paggingNumber = paggingNumber,
                    status_code = "200"
                };

            }
            catch (Exception e)
            {
                return new Response<Result>
                {
                    Success = false,
                    error = e.Message,
                    status_code = "500"
                };
            }
        }
        #endregion

        #region Get 
        public async Task<Response<Result>> Get_ResultAsync(int Id)
        {
            try
            {
                var Result = await _db.Results.Where(n => n.ResultId == Id).FirstOrDefaultAsync();
                if (Result == null)
                {
                    return new Response<Result>
                    {
                        Success = false,
                        status_code = "200",
                        Message = "Result Not found",

                    };
                }
                return new Response<Result>
                {
                    Success = true,
                    Message = "the patient",
                    status_code = "200",
                    ObjectData = Result
                };

            }
            catch (Exception e)
            {
                return new Response<Result>
                {
                    Success = false,
                    error = e.Message,
                    status_code = "500"
                };

            }
        }
        #endregion

    }
}
