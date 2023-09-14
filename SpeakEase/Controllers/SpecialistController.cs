using BLL.Services.IServices;
using DAL.Enum;
using DAL.Models.SpecialistModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SpeakEase.DAL.Entities;

namespace SpeakEase.Controllers
{
    [Authorize(Roles = "Server,Admin,SuperAdmin")]
    [Route("api/[controller]")]
    [ApiController]
    public class SpecialistController : ControllerBase
    {

        #region Depend Injection
        private readonly ISpecialistServices _specialistServices;
        private readonly UserManager<ApplicationUser> _userManager;
        public SpecialistController(ISpecialistServices specialistServices, UserManager<ApplicationUser> userManager)
        {
            _specialistServices = specialistServices;
            _userManager = userManager;
        }
        #endregion
 
        #region Get 
        [HttpGet ("Get Specialist By Id")]
        [Authorize(Roles = "Server,Admin,SuperAdmin")]

        public async Task<IActionResult> GetSpecialistByIdAsync(int specialistId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _specialistServices.GetSpecialistAsync(specialistId);

            return Ok(result);
        }
        #endregion

        #region Get All
        [HttpGet("Get Specialists")]
        [Authorize(Roles = "Server,Admin,SuperAdmin")]

        public async Task<IActionResult> GetSpecialistsAsync(int paggingNumber)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _specialistServices.GetAllSpecialistAsync(paggingNumber);

            return Ok(result);
        }
        #endregion

        #region Update  
        [HttpPut("Edit Spetialist")]
        [Authorize(Roles = "Server,Admin,SuperAdmin")]
        public async Task<IActionResult> EditSpecialistInSpetialistRequestAsync([FromForm] SpecialistVMEdit specialist)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _specialistServices.EditSpecialistAsync(specialist);

            return Ok(result);
        }
        #endregion

        #region Delete 
        [HttpDelete("Remove Specialist")]
        [Authorize(Roles = "Server,Admin,SuperAdmin")]
        public async Task<IActionResult> RemoveSpecialistAsync(int SpecialistId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _specialistServices.DeleteSpecialistAsync(SpecialistId);

            return Ok(result);
        }
        #endregion

        
    }
}
