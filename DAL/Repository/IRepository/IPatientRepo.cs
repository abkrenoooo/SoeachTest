using SpeakEase.DAL.Entities;
using SpeakEase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository.IRepository
{
    public interface IPatientRepo
    {
        Task<Response<Patient>> Create_PatientAsync(Patient patient, string id);
        Task<Response<Patient>> Delete_PatientAsync(int Id);
        Task<Response<Patient>> Get_PatientAsync(string userId, int patientId);
        Task<Response<Patient>> GetAll_PatientAsync(string userId, int paggingNumber);
        Task<Response<Patient>> Get_PatientAsync(int patientId);
        Task<Response<Patient>> GetAll_PatientAsync(int paggingNumber);
        Task<Response<Patient>> EditPatientAsync(Patient patient);

    }
}
