using BLL.Services.IServices;
using DAL.Models.SpecialistModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SpeakEase.DAL.Entities;

namespace SpeakEase.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class SpecialistController : ControllerBase
    {
        #region Depend Injecktion
        private readonly ISpecialistServices _specialistServices;
        private readonly UserManager<ApplicationUser> _userManager;
        public SpecialistController(ISpecialistServices specialistServices, UserManager<ApplicationUser> userManager)
        {
            _specialistServices = specialistServices;
            _userManager = userManager;
        }
        #endregion
 

        #region Get Specialist By Id
        [HttpGet ("Get Specialist By Id")]
        [AllowAnonymous]
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

        #region Get Specialists
        [HttpGet("Get Specialists")]
        [AllowAnonymous]
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

        #region Edit Spetialist 
        [HttpPut("Edit Spetialist")]
        [AllowAnonymous]
        public async Task<IActionResult> EditSpecialistInSpetialistRequestAsync(SpecialistVM specialist)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _specialistServices.EditSpecialistAsync(specialist);

            return Ok(result);
        }
        #endregion



        #region Remove Specialist
        [HttpDelete("Remove Specialist")]
        [AllowAnonymous]
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
