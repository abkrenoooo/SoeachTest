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
    public class ChearController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IChearService _chearService;

        public ChearController(UserManager<ApplicationUser> userManager, IChearService chearService)
        {
            _userManager = userManager;
            _chearService = chearService;
        }
        //[Authorize]
        [HttpPost("AddChear")]
        public async Task<IActionResult> AddChear([FromForm] ChearVM chear)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var result = await _chearService.CreateChearAsync(chear);
            return Ok(result);
        }
        //[Authorize]
        [HttpGet("GetChear")]
        public async Task<IActionResult> GetChear(int ChearId)
        {
            var result = await _chearService.GetChearAsync(ChearId);
            return Ok(result);
        }
        //[Authorize]
        [HttpDelete("DeleteChear")]
        public async Task<IActionResult> DeleteChear(int ChearId)
        {
            var result = await _chearService.DeleteChearAsync(ChearId);
            return Ok(result);
        }
        //[Authorize]
        [HttpPut("UpdateChear")]
        public async Task<IActionResult> UpdateChear([FromForm] ChearEditVM chear)
        {
            var result = await _chearService.UpdateChearAsync(chear);
            return Ok(result);
        }
    }
}
