using DAL.Models.SpecialistModel;
using SpeakEase.DAL.Entities;
using SpeakEase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.IServices
{
    public interface ISpecialistServices
    {
        Task<Response<SpecialistVM>> EditSpecialistAsync(SpecialistVMEdit SpecialistVM);
        Task<Response<SpecialistVM>> DeleteSpecialistAsync(int Id);
        Task<Response<SpecialistVM>> GetSpecialistAsync(int Id);
        Task<Response<SpecialistVM>> GetAllSpecialistAsync(int paggingNumber);
    }
}
