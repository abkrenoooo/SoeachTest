using BLL.Services.IServices;
using DAL.Models.Result;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SpeakEase.DAL.Entities;
using System.Security.Claims;

namespace SpeakEase.Controllers
{
    [Authorize(Roles = "Server,Admin,SuperAdmin,User")]
    [Route("api/[controller]")]
    [ApiController]
    public class ResultController : ControllerBase
    {
        #region Depend Injection
        private readonly IResultServices _resultServices;
        private readonly UserManager<ApplicationUser> _userManager;
        public ResultController(IResultServices resultServices, UserManager<ApplicationUser> userManager)
        {
            _resultServices = resultServices;
            _userManager = userManager;
        }
        #endregion

        #region Create
        [Authorize(Roles = "User")]
        [HttpPost("Add Result")]
        public async Task<IActionResult> AddResult(ResultVM Result)
        {
            var id = User.FindFirstValue("uid");
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var result = await _resultServices.Create_ResultAsync(Result, id);
            return Ok(result);
        }
        #endregion

        #region Get
        [Authorize(Roles = "Server,Admin,SuperAdmin,User")]
        [HttpGet("Get Result")]
        public async Task<IActionResult> GetResult(int ResultId)
        {
            var result = await _resultServices.Get_ResultAsync(ResultId);
            return Ok(result);
        }
        #endregion

        #region Delete Result
        [Authorize(Roles = "Server,SuperAdmin,User")]
        [HttpDelete("Delet Result")]
        public async Task<IActionResult> Delete_ResultAsync(int Id)
        {
            var id = User.FindFirstValue("uid");
            var result = await _resultServices.Delete_ResultAsync(Id, id);
            return Ok(result);
        }
        #endregion

        #region Get All Result For Patient 
        [Authorize(Roles = "Server,Admin,SuperAdmin,User")]
        [HttpGet("Get All Result For Patient")]
        public async Task<IActionResult> GetAll_ResultForPatientAsync(int patientId, int paggingNumber)
        {
            var result = await _resultServices.GetAll_ResultForPatientAsync(patientId, paggingNumber);
            return Ok(result);
        }
        #endregion

        #region Get All Result For Patient Of Spetialist
        [Authorize(Roles = "Server,Admin,SuperAdmin,User")]
        [HttpGet("Get All Result For Patient Of Spetialist")]
        public async Task<IActionResult> GetAll_ResultForPatientOfSpetialistAsync(int paggingNumber)
        {
            var id = User.FindFirstValue("uid");
            var result = await _resultServices.GetAll_ResultForPatientOfSpetialistAsync(id, paggingNumber);
            return Ok(result);
        }
        #endregion

        #region Get All Result
        [Authorize(Roles = "Server,Admin,SuperAdmin")]
        [HttpGet("Get All Result")]
        public async Task<IActionResult> GetAll_ResultAsync(int paggingNumber)
        {
            var result = await _resultServices.GetAll_ResultAsync(paggingNumber);
            return Ok(result);
        }
        #endregion

        #region Updete
        [Authorize(Roles = "Server,SuperAdmin,User")]
        [HttpPut("Update Result")]
        public async Task<IActionResult> EditResultAsync(ResultVM result )
        {
            var id = User.FindFirstValue("uid");
            var result01 = await _resultServices.EditResultAsync(result, id);
            return Ok(result01);
        }
        #endregion
    }
}
