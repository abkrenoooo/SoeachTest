using BlL.Helper;
using BLL.Services.IServices;
using DAL.Models.TestModel;
using DAL.Repository.IRepository;
using SpeakEase.DAL.Entities;
using SpeakEase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.Services
{
    public class ChearService:IChearService
    {
        private readonly IChearRepo _chearRepo;

        public ChearService(IChearRepo chearRepo)
        {
            _chearRepo = chearRepo;
        }

        public async Task<Response<Chear>> CreateChearAsync(ChearVM chear)
        {
            try
            {
                var UploadFileAudo = UploadFileHelper.SaveFile(chear.Audio, "Chear/Audo");
                var UploadFileImage = UploadFileHelper.SaveFile(chear.Image, "Chear/Image");

                Chear chear1 = new Chear();
                chear1.Audio = UploadFileAudo[1];
                chear1.Image = UploadFileImage[1];
                chear1.Word = chear.Word;
                chear1.TestId = chear.TestId;

                var result = await _chearRepo.Create_ChearAsync(chear1);
                return result;

            }
            catch (Exception e)
            {
                return new Response<Chear>
                {
                    Success = false,
                    status_code = "500",
                    error = e.Message
                };
            }
        }

        public async Task<Response<Chear>> DeleteChearAsync(int ChearId)
        {
            try
            {
                var rsult = await _chearRepo.Delete_ChearAsync(ChearId);
                if (rsult.Success==true&&rsult.status_code=="200")
                {
                    string Aduo = rsult.ObjectData.Audio;
                    UploadFileHelper.RemoveFile(Aduo);
                    UploadFileHelper.RemoveFile(rsult.ObjectData.Image);
                }
                return rsult;
            }
            catch (Exception e)
            {
                return new Response<Chear>
                {
                    Success = false,
                    status_code = "500",
                    error = e.Message
                };
            }
        }

        public async Task<Response<Chear>> GetAllChearAsync(int Pagging)
        {
            try
            {
                return new Response<Chear>
                {
                    Success = false,
                    status_code = "500"
                };
            }
            catch (Exception e)
            {
                return new Response<Chear>
                {
                    Success = false,
                    status_code = "500",
                    error = e.Message
                };
            }
        }

        public async Task<Response<object>> GetChearAsync(int ChearId)
        {
            try
            {
                var result = await _chearRepo.Get_ChearAsync(ChearId);
                List<byte[]> filesData = new List<byte[]>
                {
                    System.IO.File.ReadAllBytes(result.ObjectData.Audio),
                    System.IO.File.ReadAllBytes(result.ObjectData.Image)
                    // Add more files as needed
                };

                // Create a dictionary to hold the file names and their corresponding data
                Dictionary<string, byte[]> filesDictionary = new Dictionary<string, byte[]>();
                filesDictionary.Add("Aduo", filesData[0]);
                filesDictionary.Add("Image", filesData[1]);




                // Convert the dictionary to JSON and return it as the response
                return new Response<object>
                {
                    Success = true,
                    ObjectData = new
                    {
                        files = filesDictionary,
                        word = result.ObjectData.Word,
                    },
                };
            }
            catch (Exception e)
            {
                return new Response<Object>
                {
                    Success = false,
                    status_code = "500",
                    error = e.Message
                };
            }
        }

        public async Task<Response<Chear>> UpdateChearAsync(int Id, ChearVM chear)
        {
            try
            {
                var UploadFileAudo = UploadFileHelper.SaveFile(chear.Audio, "Chear/Audo");
                var UploadFileImage = UploadFileHelper.SaveFile(chear.Image, "Chear/Image");

                Chear chear1 = new Chear();
                chear1.Audio = UploadFileAudo[1];
                chear1.Image = UploadFileImage[1];
                chear1.Word = chear.Word;
                chear1.TestId = chear.TestId;

                var resul = await _chearRepo.Update_ChearAsync(Id, chear1);
                return resul;
            }
            catch (Exception e)
            {
                return new Response<Chear>
                {
                    Success = false,
                    status_code = "500",
                    error = e.Message
                };
            }
        }
    }
}
