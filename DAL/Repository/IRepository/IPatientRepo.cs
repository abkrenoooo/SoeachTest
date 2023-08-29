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
        Task<Response<Patient>> Create_PatientAsync(Patient patient);
        Task<Response<Patient>> Delete_PatientAsync(int Id);
        Task<Response<Patient>> Get_PatientAsync(int Id);
        Task<Response<Patient>> GetAll_PatientAsync(int paggingNumber);
        Task<Response<Patient>> Update_PatientAsync(int Id,Patient patient);

    }
}
