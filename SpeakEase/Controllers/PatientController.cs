using BLL.Services.IServices;
using DAL.Models.Patient;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SpeakEase.DAL.Entities;
using System.Security.Claims;

namespace SpeakEase.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IPatientService _patientService;

        public PatientController(UserManager<ApplicationUser> userManager, IPatientService patientService)
        {
            _userManager = userManager;
            _patientService = patientService;
        }
        [Authorize]
        [HttpPost("AddPatient")]
        public async Task<IActionResult> AddPatient(PatientVM patientVM)
        {
            var id =User.FindFirstValue("uid");
            //patientVM.SpecialistId=Convert.ToInt32(id);
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var result=await _patientService.CreatePatientAsync(patientVM,id);
            return Ok(result);
        }
        [Authorize]
        [HttpGet("GetAllPatient")]
        public async Task<IActionResult> GetAllPatient(int pagging)
        {
            var result=_patientService.GetAllPatientAsync(pagging);
            return Ok(result);
        }
        [Authorize]
        [HttpGet("GetPatient")]
        public async Task<IActionResult> GetPatient(int Id)
        {
            var result = _patientService.GetPatientAsync(Id);
            return Ok(result);
        }
        [Authorize]
        [HttpDelete("DeletePatient")]
        public async Task<IActionResult> DeletePatient(int Id)
        {
            var result=await _patientService.DeletePatientAsync(Id);
            return Ok(result);
        }
        [Authorize]
        [HttpPut("UpdatePatient")]
        public async Task<IActionResult> EditPatient( PatientVM patientVM)
        {
            var result=await _patientService.EditPatientAsync(patientVM);
            return Ok(result);
        }
    }
}
