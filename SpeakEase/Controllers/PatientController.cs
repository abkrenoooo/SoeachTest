using BLL.Services.IServices;
using DAL.Enum;
using DAL.Models.Patient;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SpeakEase.DAL.Entities;
using System.Security.Claims;

namespace SpeakEase.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        #region Depend Injection

        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IPatientService _patientService;

        public PatientController(UserManager<ApplicationUser> userManager, IPatientService patientService)
        {
            _userManager = userManager;
            _patientService = patientService;
        }
        #endregion

        #region Create 
        [HttpPost("Add Patient")]
        [Authorize]

        public async Task<IActionResult> AddPatient(PatientVM patientVM)
        {
            var id = User.FindFirstValue("uid");
            //patientVM.SpecialistId=Convert.ToInt32(id);
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var result = await _patientService.CreatePatientAsync(patientVM, id);
            return Ok(result);
        }
        #endregion

        #region Get All Of Spetialist
        [Authorize]

        [HttpGet("Get All Patient Of Spetialist")]
        public async Task<IActionResult> GetAllPatientOfSpetialist(int pagging)
        {
            var userId = User.FindFirst("uid")!.Value;
            var result = await _patientService.GetAllPatientAsync(userId, pagging);
            return Ok(result);
        }
        #endregion

        #region Get Of Spetialist
        [Authorize]

        [HttpGet("Get Patient Of Spetialist")]
        public async Task<IActionResult> GetPatientOfSpetialist(int Id)
        {
            var userId = User.FindFirst("uid")!.Value;
            var result = await _patientService.GetPatientAsync(userId, Id);
            return Ok(result);
        }
        #endregion

        #region Get All 

        [HttpGet("Get All Patient")]
        [Authorize]

        public async Task<IActionResult> GetAllPatient(int pagging)
        {
            var result = await _patientService.GetAllPatientAsync(pagging);
            return Ok(result);
        }
        #endregion

        #region Get 
        [Authorize]

        [HttpGet("Get Patient")]
        public async Task<IActionResult> GetPatient(int Id)
        {
            var userId = User.FindFirst("uid")!.Value;
            var result = await _patientService.GetPatientAsync(Id);
            return Ok(result);
        }
        #endregion

        #region Delete 
        [Authorize]

        [HttpDelete("Delete Patient")]
        public async Task<IActionResult> DeletePatient(int Id)
        {
            var result = await _patientService.DeletePatientAsync(Id);
            return Ok(result);
        }
        #endregion

        #region Update
        [Authorize]

        [HttpPut("Update Patient")]
        public async Task<IActionResult> EditPatient(PatientVM patientVM)
        {
            var result = await _patientService.EditPatientAsync(patientVM);
            return Ok(result);
        }
        #endregion
    }
}
