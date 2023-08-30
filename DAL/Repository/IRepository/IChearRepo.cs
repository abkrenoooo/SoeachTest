using SpeakEase.DAL.Entities;
using SpeakEase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository.IRepository
{
    public interface IChearRepo
    {
        Task<Response<Chear>> Create_ChearAsync(Chear chear);
        Task<Response<Chear>> Delete_ChearAsync(int ChearId);
        Task<Response<Chear>> GetAll_ChearAsync(int Pagging);
        Task<Response<Chear>> Get_ChearAsync(int ChearId);
        Task<Response<Chear>> Update_ChearAsync(int Id,Chear chear);

    }
}
