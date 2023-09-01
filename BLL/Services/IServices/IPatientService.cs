using DAL.Models.Patient;

using SpeakEase.DAL.Entities;
using SpeakEase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.IServices
{
    public interface IPatientService
    {
        Task<Response<Patient>> CreatePatientAsync(PatientVM patientVM, string id);
        Task<Response<Patient>> EditPatientAsync(PatientVM patientVM);
        Task<Response<Patient>> DeletePatientAsync(int Id);
        Task<Response<Patient>> GetPatientAsync(string userId, int patientId);
        Task<Response<Patient>> GetAllPatientAsync(string userId,int paggingNumber);
        Task<Response<Patient>> GetPatientAsync(int patientId);
        Task<Response<Patient>> GetAllPatientAsync(int paggingNumber);
    }
}
