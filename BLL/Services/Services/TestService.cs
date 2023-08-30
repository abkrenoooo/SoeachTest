using BLL.Services.IServices;
using DAL.Models.TestModel;
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
    public class TestService:ITestService
    {
        private readonly ITestRepo _testRepo;

        public TestService(ITestRepo testRepo)
        {
            _testRepo = testRepo;
        }

        public async Task<Response<Test>> CreateTestAsync(TestVM TestVM, int SpecialictId)
        {
            try
            {
                Test test = new Test();
                test.TestId = TestVM.TestId;
                test.TestDate = TestVM.TestDate;
                test.SpecialistId = SpecialictId;

                var result = await _testRepo.Create_TestRepo(test);
                return result;
            }
            catch (Exception e)
            {
                return new Response<Test>
                {
                    Success = false,
                    status_code = "500",
                    error = e.Message
                };
            }
        }

        public async Task<Response<Test>> DeleteTestAsync(int Id)
        {
            try
            {
                var result = await _testRepo.Delete_TestRepo(Id);
                return result;
            }
            catch (Exception e)
            {
                return new Response<Test>
                {
                    Success = false,
                    status_code = "500",
                    error = e.Message
                };
            }
        }

        public async Task<Response<Test>> GetAllTestAsync(int Pagging)
        {
            try
            {
                var result = await _testRepo.GetAll_TestRepo(Pagging);
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
                return new Response<Test>
                {
                    Success = false,
                    status_code = "500",
                    error = e.Message
                };
            }
        }

        public async Task<Response<Test>> GetTestAsync(int Id)
        {
            try
            {
                var result = await _testRepo.Get_TestRepo(Id);
                return result;
            }
            catch (Exception e)
            {
                return new Response<Test>
                {
                    Success = false,
                    status_code = "500",
                    error = e.Message
                };
            }
        }

        public async Task<Response<Test>> UpdateTestAsync(int Id, TestVM TestVM,int SpecialictId)
        {
            try
            {
                Test test = new Test();
                test.TestId = TestVM.TestId;
                test.TestDate = TestVM.TestDate;
                test.SpecialistId = SpecialictId;

                var result = await _testRepo.Update_TestRepo(Id,test);
                return result;
            }
            catch (Exception e)
            {
                return new Response<Test>
                {
                    Success = false,
                    status_code = "500",
                    error = e.Message
                };
            }
        }
    }
}
