using SpeakEase.DAL.Entities;
using SpeakEase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository.IRepository
{
    public interface ISpecialistRepo
    {
        Task<bool> DeleteSpecialistAsync(int Id);
        Task<Specialist> GetSpecialistByIdAsync(int Id);
        Task<Response<Specialist>> GetAllSpecialistAsync(int paggingNumber);
        Task<Specialist> EditSpecialistAsync(Specialist Specialist);
    }
}
