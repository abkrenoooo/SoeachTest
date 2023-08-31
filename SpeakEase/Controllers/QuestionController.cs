using BLL.Services.IServices;
using DAL.Models.Chear;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SpeakEase.DAL.Entities;

namespace SpeakEase.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionController : ControllerBase
    {
        #region Depend Injection
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IChearService _chearService;

        public QuestionController(UserManager<ApplicationUser> userManager, IChearService chearService)
        {
            _userManager = userManager;
            _chearService = chearService;
        }
        #endregion

        #region Create
        //[Authorize]
        [HttpPost("Add Chear")]
        public async Task<IActionResult> AddChear([FromForm] ChearVM chear)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var result = await _chearService.CreateChearAsync(chear);
            return Ok(result);
        }
        #endregion

        #region Get
        //[Authorize]
        [HttpGet("Get Chear")]
        public async Task<IActionResult> GetChear(int ChearId)
        {
            var result = await _chearService.GetChearAsync(ChearId);
            return Ok(result);
        }
        #endregion

        #region Get All
        //[Authorize]
        [HttpGet("Get All Chear")]
        public async Task<IActionResult> GetAllChear(int Pagging)
        {
            var result = await _chearService.GetAllChearAsync(Pagging);
            return Ok(result);
        }
        #endregion

        #region Delete
        //[Authorize]
        [HttpDelete("Delete Chear")]
        public async Task<IActionResult> DeleteChear(int ChearId)
        {
            var result = await _chearService.DeleteChearAsync(ChearId);
            return Ok(result);
        }
        #endregion

        #region Updete
        //[Authorize]
        [HttpPut("Update Chear")]
        public async Task<IActionResult> UpdateChear([FromForm] ChearEditVM chear)
        {
            var result = await _chearService.UpdateChearAsync(chear);
            return Ok(result);
        }
        #endregion
    }
}
