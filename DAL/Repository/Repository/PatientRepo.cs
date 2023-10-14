using DAL.ExtensionMethods;
using DAL.Models.Patient;
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
        #region Depend Injection

        private readonly ApplicationDbContext db;

        public PatientRepo(ApplicationDbContext db)
        {
            this.db = db;
        }
        #endregion

        #region Create

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
                db.Entry(patient).Property(p => p.SpecialistId).IsModified = true;
                patient.SpecialistId = specialist.SpecialistId;
                await db.Patients.AddAsync(patient);
                await db.SaveChangesAsync();
                return new Response<Patient>
                {
                    Success = true,
                    ObjectData = patient,
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
        #endregion

        #region Delete 

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
        #endregion

        #region Get All Of Spetialist

        public async Task<Response<PatientVM>> GetAll_PatientAsync(string userId, int paggingNumber)
        {
            try
            {
                var specialist = await db.Specialists.FirstOrDefaultAsync(x => x.UserId == userId);
                if (specialist == null)
                {
                    return new Response<PatientVM>
                    {
                        Success = false,
                        error = "This Spetialist not Found",
                        status_code = "404"
                    };
                }
                int AllPatientcount = await db.Patients.Where(x => x.SpecialistId == specialist.SpecialistId).CountAsync();
                var AllPatient = await db.Patients.Where(x => x.SpecialistId == specialist.SpecialistId).Skip((paggingNumber - 1) * 10).Take(10).ToListAsync(); 

                return new Response<PatientVM>
                {
                    Success = true,
                    Message = "All patient",
                    Data = AllPatient.ConvertAll(x=>x.FromPatient().Result),
                    CountOfData = AllPatientcount,
                    paggingNumber = paggingNumber,
                    status_code = "200"
                };

            }
            catch (Exception e)
            {
                return new Response<PatientVM>
                {
                    Success = false,
                    error = e.Message,
                    status_code = "500"
                };
            }
        }
        #endregion

        #region Get Patient 

        public async Task<Response<Patient>> Get_PatientAsync(string userId, int patientId)
        {
            try
            {
                var specialist = await db.Specialists.Where(x => x.UserId == userId).FirstOrDefaultAsync();
                if (specialist == null)
                {
                    return new Response<Patient>
                    {
                        Success = false,
                        error = "This Spetialist not Found",
                        status_code = "404"
                    };
                }
                var patient = await db.Patients.Where(n => n.SpecialistId == specialist.SpecialistId && n.PatientId == patientId).FirstOrDefaultAsync();
                if (patient == null)
                {
                    return new Response<Patient>
                    {
                        Success = false,
                        status_code = "200",
                        Message = "Patient Not found",

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
        #endregion

        #region Get All

        public async Task<Response<Patient>> GetAll_PatientAsync( int paggingNumber)
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
        #endregion

        #region Get 

        public async Task<Response<Patient>> Get_PatientAsync( int patientId)
        {
            try
            {
                
                var patient = await db.Patients.Where(n => n.PatientId == patientId).FirstOrDefaultAsync();
                if (patient == null)
                {
                    return new Response<Patient>
                    {
                        Success = false,
                        status_code = "200",
                        Message = "Patient Not found",

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
        #endregion

        #region Update 

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
                patient.Specialist = null;

                return new Response<Patient>
                {
                    Success = true,
                    ObjectData = patient2,
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
        #endregion
    }
}
