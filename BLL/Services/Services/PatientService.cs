using BLL.Services.IServices;
using DAL.Models.Patient;
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
    public class PatientService:IPatientService
    {
        private readonly IPatientRepo _patientRepo;

        public PatientService(IPatientRepo patientRepo)
        {
            _patientRepo = patientRepo;
        }

        public async Task<Response<Patient>> CreatePatientAsync(PatientVM patientVM)
        {
            try
            {
                Patient patient = new Patient();
                patient.BirithDate = patientVM.BirithDate;
                patient.FirstName = patientVM.FirstName;
                patient.SecondName = patientVM.SecondName;
                patient.LastName = patientVM.LastName;
                patient.Note = patientVM.Note;
                patient.Gender = patientVM.Gender;
                patient.EducationState = patientVM.EducationState;
                patient.OME = patientVM.OME;
                patient.SpecialistId = patientVM.SpecialitId;

                var result = await _patientRepo.Create_PatientAsync(patient);
                return result;

            }
            catch (Exception e)
            {
                return new Response<Patient>
                {
                    Success=false,
                    error=e.Message 
                };
            }
        }

        public async Task<Response<Patient>> DeletePatientAsync(int Id)
        {
            try
            {
                var result = await _patientRepo.Delete_PatientAsync(Id);
                return result;
            }
            catch (Exception e)
            {
                return new Response<Patient>
                {
                    Success = false,
                    error = e.Message
                };
            }
        }

        public async Task<Response<Patient>> GetAllPatientAsync(int paggingNumber)
        {
            try
            {
                var result= await _patientRepo.GetAll_PatientAsync(paggingNumber);
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
                return new Response<Patient>
                {
                    Success = false,
                    error = e.Message
                };
            }
        }

        public async Task<Response<Patient>> GetPatientAsync(int Id)
        {
            try
            {
                var result = await _patientRepo.Get_PatientAsync(Id);
                return result;
            }
            catch (Exception e)
            {
                return new Response<Patient>
                {
                    Success = false,
                    error = e.Message
                };
            }
        }

        public async Task<Response<Patient>> UpdatePatientAsync(int Id, PatientVM patientVM)
        {
            try
            {
                Patient patient = new Patient();
                patient.BirithDate = patientVM.BirithDate;
                patient.FirstName = patientVM.FirstName;
                patient.SecondName = patientVM.SecondName;
                patient.LastName = patientVM.LastName;
                patient.Note = patientVM.Note;
                patient.Gender = patientVM.Gender;
                patient.EducationState = patientVM.EducationState;
                patient.OME = patientVM.OME;
                patient.SpecialistId = patientVM.SpecialitId;

                var result = await _patientRepo.Update_PatientAsync(Id, patient);
                return result;
            }
            catch (Exception e)
            {
                return new Response<Patient>
                {
                    Success = false,
                    error = e.Message
                };
            }
        }
    }
}
