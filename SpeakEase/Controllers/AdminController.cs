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
        
        #region Remove Admin
        [HttpPost("Remove Admin")]
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
