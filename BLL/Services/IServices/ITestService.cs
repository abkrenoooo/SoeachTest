using DAL.Models.TestModel;
using SpeakEase.DAL.Entities;
using SpeakEase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.IServices
{
    public interface ITestService
    {
        Task<Response<Test>> CreateTestAsync(TestVM TestVM, int SpecialictId);
        Task<Response<Test>> DeleteTestAsync(int Id);
        Task<Response<Test>> GetTestAsync(int Id);
        Task<Response<Test>> GetAllTestAsync(int Pagging);
        Task<Response<Test>> UpdateTestAsync(int Id, TestVM TestVM,int SpecialistId);
    }
}
