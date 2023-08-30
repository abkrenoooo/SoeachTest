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
    public class PatientRepo : IPatientRepo
    {
        private readonly ApplicationDbContext db;
        private readonly ITestRepo _testRepo;

        public PatientRepo(ApplicationDbContext db, ITestRepo testRepo)
        {
            this.db = db;
            _testRepo = testRepo;
        }

        public async Task<Response<Patient>> Create_PatientAsync(Patient patient, string id)
        {
            try
            {
                var specialist = await db.Specialists.FirstOrDefaultAsync(x => x.UserId == id);
                if (specialist == null)
                {
                    return new Response<Patient>
                    {
                        Success = true,
                        Message = "Specialist not correct",
                        status_code = "404"
                    };
                }
                Test test = new Test()
                {
                    TestName = String.Concat(patient.FirstName, " ", patient.SecondName, " ", patient.LastName, "Test"),
                    TestDate = DateTime.Now,
                    SpecialistId= specialist.SpecialistId
                };
                await _testRepo.Create_TestRepo(test);
                await db.SaveChangesAsync();
                db.Entry(patient).Property(p => p.SpecialistId).IsModified = true;
                patient.SpecialistId = specialist.SpecialistId;
                patient.TestId = test.TestId;
                await db.Patients.AddAsync(patient);
                await db.SaveChangesAsync();

                return new Response<Patient>
                {
                    Success = true,
                    ObjectData=patient,
                    Message = "Created the patient",
                    status_code = "200"
                };
            }
            catch (Exception e)
            {
                return new Response<Patient>
                {
                    Success = false,
                    error = e.Message,
                    status_code = "500"
                };
            }
        }

        public async Task<Response<Patient>> Delete_PatientAsync(int Id)
        {
            try
            {
                var patient = await db.Patients.Where(n => n.PatientId == Id).SingleOrDefaultAsync();
                if (patient == null)
                {
                    return new Response<Patient>
                    {
                        Success = false,
                        Message = "Can not found this patient",
                        status_code = "200"
                    };
                }
                db.Patients.Remove(patient);
                await db.SaveChangesAsync();

                return new Response<Patient>
                {
                    Success = true,
                    Message = "patient is Deleted",
                    status_code = "200"
                };

            }
            catch (Exception e)
            {
                return new Response<Patient>
                {
                    Success = false,
                    error = e.Message,
                    status_code = "500"
                };
            }
        }

        public async Task<Response<Patient>> GetAll_PatientAsync(int paggingNumber)
        {
            try
            {
                int AllPatientcount = await db.Patients.CountAsync();
                var AllPatient = await db.Patients.Skip((paggingNumber - 1) * 10).Take(10).ToListAsync(); ;
                return new Response<Patient>
                {
                    Success = true,
                    Message = "All patient",
                    Data = AllPatient,
                    CountOfData = AllPatientcount,
                    paggingNumber = paggingNumber,
                    status_code = "200"
                };

            }
            catch (Exception e)
            {
                return new Response<Patient>
                {
                    Success = false,
                    error = e.Message,
                    status_code = "500"
                };
            }
        }

        public async Task<Response<Patient>> Get_PatientAsync(int Id)
        {
            try
            {
                var patient = await db.Patients.Where(n => n.PatientId == Id).SingleOrDefaultAsync();
                if (patient == null)
                {
                    return new Response<Patient>
                    {
                        Success = false,
                        status_code = "200",
                        Message = "Not found",

                    };
                }
                return new Response<Patient>
                {
                    Success = true,
                    Message = "the patient",
                    status_code = "200",
                    ObjectData = patient
                };

            }
            catch (Exception e)
            {
                return new Response<Patient>
                {
                    Success = false,
                    error = e.Message,
                    status_code = "500"
                };
            }
        }

        public async Task<Response<Patient>> EditPatientAsync(Patient patient)

        {
            try
            {
                var patient2 = await db.Patients.Where(n => n.PatientId == patient.PatientId).SingleOrDefaultAsync();
                if (patient == null || patient2 == null)
                {
                    return new Response<Patient>
                    {
                        Success = false,
                        status_code = "200",
                        Message = "Not found",

                    };
                }
                patient2.FirstName = patient.FirstName;
                patient2.SecondName = patient.SecondName;
                patient2.LastName = patient.LastName;
                patient2.BirithDate = patient.BirithDate;
                patient2.Gender = patient.Gender;
                patient2.OME = patient.OME;
                patient2.EducationState = patient.EducationState;
                patient2.Note = patient.Note;

                await db.SaveChangesAsync();
                return new Response<Patient>
                {
                    Success = true,
                    ObjectData=patient2,
                    Message = "patient is Updated",
                    status_code = "200"
                };

            }
            catch (Exception e)
            {
                return new Response<Patient>
                {
                    Success = false,
                    error = e.Message,
                    status_code = "500"
                };
            }
        }
    }
}
