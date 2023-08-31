using DAL.Models.TestModel;
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
    public class ChearRepo:IChearRepo
    {
        private readonly ApplicationDbContext db;

        public ChearRepo(ApplicationDbContext db)
        {
            this.db = db;
        }

        public async Task<Response<Chear>> Create_ChearAsync(Chear chear)
        {
            try
            {
                var chearsCount=  await db.Chears.Where(x=>x.Character==chear.Character&&x.ChearPosition==chear.ChearPosition).CountAsync();
                if (chearsCount == 0)
                {
                    await db.Chears.AddAsync(chear);
                    await db.SaveChangesAsync();
                    return new Response<Chear>
                    {
                        Success = true,
                        Message = "Created Chear",
                        status_code = "200",
                        ObjectData=chear    
                    };
                }
                return new Response<Chear>
                {
                    Success = true,
                    Message = "Qustion With the same Character and Character Position is found before",
                    status_code = "500",
                };
            }
            catch (Exception e)
            {
                return new Response<Chear> { 
                    Success=true,
                    error=e.Message,
                    status_code="500"
                };
            }
        }

        public async Task<Response<Chear>> Delete_ChearAsync(int ChearId)
        {
            try
            {
                var chear = await db.Chears.Where(n => n.ChearId == ChearId).SingleOrDefaultAsync();
                if (chear == null)
                {
                    return new Response<Chear>
                    {
                        Success = true,
                        Message = "this chear Not Found",
                        status_code = "200"
                    };
                }
                db.Chears.Remove(chear);
                await db.SaveChangesAsync();
                return new Response<Chear>
                {
                    Success = true,
                    Message = "Created Chear",
                    status_code = "200",
                    ObjectData=chear
                };
            }
            catch (Exception e)
            {
                return new Response<Chear>
                {
                    Success = true,
                    error = e.Message,
                    status_code = "500"
                };
            }
        }

        public async Task<Response<Chear>> GetAll_ChearAsync(int Pagging)
        {
            try
            {
                int AllChearCount = await db.Chears.CountAsync();
                var AllChear = await db.Chears.Skip((Pagging - 1) * 10).Take(10).
                    
                    ToListAsync();
                return new Response<Chear>
                {
                    Success = true,
                    status_code = "200",
                    Data = AllChear,
                    CountOfData = AllChearCount,
                    Message = "All chear for patient"
                };
            }
            catch (Exception e)
            {
                return new Response<Chear>
                {
                    Success = true,
                    error = e.Message,
                    status_code = "500"
                };
            }
        }

        public async Task<Response<Chear>> Get_ChearAsync(int ChearId)
        {
            try
            {
                var chear = await db.Chears.Where(n => n.ChearId == ChearId).SingleOrDefaultAsync();
                if (chear == null)
                {
                    return new Response<Chear>
                    {
                        Success = true,
                        Message = "this chear Not Found",
                        status_code = "200"
                    };
                }
                return new Response<Chear>
                {
                    Success = true,
                    Message = "Created Chear",
                    status_code = "200",
                    ObjectData=chear
                };
            }
            catch (Exception e)
            {
                return new Response<Chear>
                {
                    Success = true,
                    error = e.Message,
                    status_code = "500"
                };
            }
        }

        public async Task<Response<Chear>> Update_ChearAsync(Chear chear2)
        {
            try
            {
                var chear = await db.Chears.Where(n => n.ChearId == chear2.ChearId).SingleOrDefaultAsync();
                if (chear == null)
                {
                    return new Response<Chear>
                    {
                        Success = true,
                        Message = "this chear Not Found",
                        status_code = "200"
                    };
                }
                var chearsCount = await db.Chears.Where(x => x.Character == chear.Character && x.ChearPosition == chear.ChearPosition).CountAsync();
                if (chearsCount != 0)
                {
                    return new Response<Chear>
                    {
                        Success = true,
                        Message = "Qustion With the same Character and Character Position is found before",
                        status_code = "500",
                    };
                }
                chear.Audio = chear2.Audio==null? chear.Audio: chear2.Audio;
                chear.Word = chear2.Word == null ? chear.Word : chear2.Word; 
                chear.Image = chear2.Image == null ? chear.Image : chear2.Image;
                chear.TestId = chear2.TestId == null ? chear.TestId : chear2.TestId;

                await db.SaveChangesAsync();

                return new Response<Chear>
                {
                    Success = true,
                    Message = "Created Chear",
                    status_code = "200"
                };
            }
            catch (Exception e)
            {
                return new Response<Chear>
                {
                    Success = true,
                    error = e.Message,
                    status_code = "500"
                };
            }
        }
    }
}
