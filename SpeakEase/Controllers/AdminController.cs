using BLL.Services.IServices;
using BLL.Services.Services;
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
    public class AdminController : ControllerBase
    {
        #region Depend Injecktion
        private readonly IAdminSevices _adminService;
        private readonly UserManager<ApplicationUser> _userManager;
        public AdminController(IAdminSevices adminService, UserManager<ApplicationUser> userManager)
        {
            _adminService = adminService;
            _userManager = userManager;
        }
        #endregion

        #region Add Admin
        [HttpPost("Add Admin")]
        [AllowAnonymous]
        public async Task<IActionResult> AddAdminUserAsync(AdminUserVM model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _adminService.AddAdminUserAsync(model);

            return Ok(result);
        }
        #endregion

        #region Get All Spetialist Requst
        [HttpGet("Get All Spetialist Requst")]
        [AllowAnonymous]
        public async Task<IActionResult> GetAdminUserAllSpetialistRequstAsync(int paggingNumber)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _adminService.GetAdminUserAllSpetialistRequstAsync(paggingNumber);

            return Ok(result);
        }
        #endregion

        #region Get Admin By Id
        [HttpGet ("Get Admin By Id")]
        [AllowAnonymous]
        public async Task<IActionResult> GetAdminUserByIdAsync(string AdminUserId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _adminService.GetAdminUserByIdAsync(AdminUserId);

            return Ok(result);
        }
        #endregion

        #region Get Admins
        [HttpGet("Get Admins")]
        [AllowAnonymous]
        public async Task<IActionResult> GetAdminUsersAsync(int paggingNumber)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _adminService.GetAdminUsersAsync(paggingNumber);

            return Ok(result);
        }
        #endregion

        #region Edit In Spetialist Requst
        [HttpPut("Edit In Spetialist Requst")]
        [AllowAnonymous]
        public async Task<IActionResult> EditAdminUserInSpetialistRequestAsync(int SpetialistId, bool Accepted)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _adminService.EditAdminUserInSpetialistRequestAsync(SpetialistId, Accepted);

            return Ok(result);
        }
        #endregion

        #region Edit Admin
        [HttpPut("Edit Admin")]
        [AllowAnonymous]
        public async Task<IActionResult> EditAdminUserAsync(AdminUserVM model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _adminService.EditAdminUserAsync(model);

            return Ok(result);
        }
        #endregion

        #region Remove Admin
        [HttpDelete("Remove Admin")]
        [AllowAnonymous]
        public async Task<IActionResult> RemoveAdminUserAsync(string AdminId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _adminService.RemoveAdminUserAsync(AdminId);

            return Ok(result);
        }
        #endregion

    }
}
