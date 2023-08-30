using Bll.ExtensionMethods;
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

        public async Task<Response<Patient>> CreatePatientAsync(PatientVM patientVM,string id)
        {
            try
            {
                var result = await _patientRepo.Create_PatientAsync(patientVM.ToPatient().Result, id);
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

        public async Task<Response<Patient>> EditPatientAsync(PatientVM patientVM)
        {
            try
            {
                var result = await _patientRepo.EditPatientAsync(patientVM.ToPatient().Result);
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
