using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using Microsoft.AspNetCore.Http;
using System.Net.Http.Headers;
using DAL.Entities;

namespace BlL.Helper
{
    public static class UploadFileHelper
    {
        public static string[] SaveFile(IFormFile FileUrl, string FolderPath)
        {
            string[] arr = new string[2];
            // Get Directory
            string FilePath = Directory.GetCurrentDirectory() + "/wwwroot/" + FolderPath;

            // Get File Name
            string FileName = Guid.NewGuid() + Path.GetFileName(FileUrl.FileName);
            arr[0] = FileName;
            // Merge The Directory With File Name
            string FinalPath = Path.Combine(FilePath, FileName);
            arr[1] = FinalPath;
            // Save Your File As Stream "Data Overtime"
            using (var Stream = new FileStream(FinalPath, FileMode.Create))
            {
                FileUrl.CopyTo(Stream);
            }
            return arr;
        }

        //public static async Task<byte[]> UploadFile(IFormFile file)
        //{   
        //        using (var memoryStream = new MemoryStream())
        //        {
        //            await file.CopyToAsync(memoryStream);
        //            byte[] fileData = memoryStream.ToArray();
        //            return fileData;
        //        }
        //}
        public static async Task<files> UploadFile(IFormFile filename)
        {
            using (var memoryStream = new MemoryStream())
            {
                await filename.CopyToAsync(memoryStream);
                byte[] fileData = memoryStream.ToArray();
                var File = new files
                {
                    FileName = filename.FileName,
                    ContentType = filename.ContentType,
                    Data = fileData
                };
                return File;
            }
        }

        public static void RemoveFile(string Filepath)
        {
            if (File.Exists(Directory.GetCurrentDirectory() + "/wwwroot" + Filepath))
            {
                File.Delete(Directory.GetCurrentDirectory() + "/wwwroot" + Filepath);
            }

        }
        public static async Task<string> UploadToExternalServer(IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                return "No";
            }

            // Replace with the URL of the external server where you want to upload the file.
            var externalServerUrl = "https://drive.google.com/drive/folders/1XQ6t_8d3YxFaT2tVj_mjeUg6bZZ_z7_H";

            using (var httpClient = new HttpClient())
            {
                using (var form = new MultipartFormDataContent())
                {
                    form.Headers.ContentType.MediaType = "multipart/form-data";
                    form.Add(new StreamContent(file.OpenReadStream())
                    {
                        Headers =
                        {
                            ContentLength = file.Length,
                            ContentType = new MediaTypeHeaderValue(file.ContentType)
                        }
                    }, "file", file.FileName);

                    var response = await httpClient.PostAsync(externalServerUrl, form);

                    if (response.IsSuccessStatusCode)
                    {
                        // The file was successfully uploaded to the external server.
                        // Now you can handle the response from the external server,
                        // which may include the path to the uploaded file.
                        var responseContent = await response.Content.ReadAsStringAsync();

                        // You can save the path to the database or process it as needed.

                        return "Yes";
                    }
                }
            }

            return "No";
        }
    }
}
