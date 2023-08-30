using DAL.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using SpeakEase.DAL.Data;
using SpeakEase.DAL.Entities;
using SpeakEase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository.Repository
{
    public class TestRepo:ITestRepo
    {
        private readonly ApplicationDbContext db;

        public TestRepo(ApplicationDbContext db)
        {
            this.db = db;
        }

        public async Task<Response<Test>> Create_TestRepo(Test test)
        {
            try
            {
                
                await db.Tests.AddAsync(test);
                await db.SaveChangesAsync();
                return new Response<Test>
                {
                    Success = true,
                    Message="Create Test for patient"
                };
            }
            catch (Exception e)
            {
                return new Response<Test>
                {
                    Success = false,
                    error = e.Message
                };
            }
        }

        public async Task<Response<Test>> Delete_TestRepo(int Id)
        {
            try
            {
                var test = await db.Tests.Where(n => n.TestId == Id).SingleOrDefaultAsync();
                db.Tests.Remove(test);
                db.SaveChangesAsync();
                return new Response<Test>
                {
                    Success = true,
                    Message = "Deleted Test for patient"
                };
            }
            catch (Exception e)
            {
                return new Response<Test>
                {
                    Success = false,
                    error = e.Message
                };
            }
        }

        public async Task<Response<Test>> GetAll_TestRepo(int Pagging)
        {
            try
            {
                int AllTestCount = await db.Tests.CountAsync();
                var AllTest = await db.Tests.Skip((Pagging - 1) * 10).Take(10).
                    //Select(n => new { n.TestName, n.TestDate, n.Patient, n.Specialist }).
                    ToListAsync();
                return new Response<Test>
                {
                    Success = true,
                    status_code="200",
                    Data=AllTest,
                    CountOfData=AllTestCount,
                    Message = "All Test for patient"
                };
            }
            catch (Exception e)
            {
                return new Response<Test>
                {
                    Success = false,
                    status_code="500",
                    error = e.Message
                };
            }
        }

        public async Task<Response<Test>> Get_TestRepo(int Id)
        {
            try
            {
                var test = await db.Tests.Where(n => n.TestId == Id).SingleOrDefaultAsync();
                return new Response<Test>
                {
                    Success = true,
                    status_code="200",
                    ObjectData=test,
                    Message = "Test for patient"
                };
            }
            catch (Exception e)
            {
                return new Response<Test>
                {
                    Success = false,
                    error = e.Message
                };
            }
        }

        public async Task<Response<Test>> Update_TestRepo(int Id, Test test)
        {
            try
            {
                var test2 = await db.Tests.Where(n => n.TestId == Id).SingleOrDefaultAsync();
                test2.TestName = test.TestName;
                test2.TestDate = test.TestDate;
                await db.SaveChangesAsync();
                return new Response<Test>
                {
                    Success = true,
                    Message = "Update Test for patient"
                };
            }
            catch (Exception e)
            {
                return new Response<Test>
                {
                    Success = false,
                    error = e.Message
                };
            }
        }
    }
}
