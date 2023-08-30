using DAL.Models.TestModel;
using SpeakEase.DAL.Entities;
using SpeakEase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository.IRepository
{
    public interface ITestRepo
    {
        Task<Response<Test>> Create_TestRepo(Test test);
        Task<Response<Test>> Delete_TestRepo(int Id);
        Task<Response<Test>> Get_TestRepo(int Id);
        Task<Response<Test>> GetAll_TestRepo(int Pagging);
        Task<Response<Test>> Update_TestRepo(int Id,Test test);

    }
}
