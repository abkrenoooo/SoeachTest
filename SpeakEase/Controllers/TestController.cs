using BLL.Services.IServices;
using BLL.Services.Services;
using DAL.Models.Patient;
using DAL.Models.TestModel;
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
    public class TestController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ITestService _testServic;

        public TestController(UserManager<ApplicationUser> userManager, ITestService testServic)
        {
            _userManager = userManager;
            _testServic = testServic;
        }
        //[Authorize]
        [HttpPost("AddTest")]
        public async Task<IActionResult> AddTest(TestVM testVM)
        {
            try
            {
                var Id = User.FindFirstValue("uid");
                int id = Convert.ToInt32(Id);
                if(!ModelState.IsValid) { return BadRequest(ModelState); }
                var result = await _testServic.CreateTestAsync(testVM,id);
                return Ok(result);
            }
            catch (Exception e)
            {
                return Ok(e.Message);
            }
        }
        //[Authorize]
        [HttpGet("GetAllTest")]
        public async Task<IActionResult> GetAllTest(int pagging)
        {
            var result = _testServic.GetAllTestAsync(pagging);
            return Ok(result);
        }
        //[Authorize]
        [HttpGet("GetTest")]
        public async Task<IActionResult> GetTest(int Id)
        {
            var result = _testServic.GetTestAsync(Id);
            return Ok(result);
        }
        //[Authorize]
        [HttpDelete("DeleteTest")]
        public async Task<IActionResult> DeleteTest(int Id)
        {
            var result = await _testServic.DeleteTestAsync(Id);
            return Ok(result);
        }
        //[Authorize]
        [HttpPut("UpdateTest")]
        public async Task<IActionResult> UpdateTest(int Id, TestVM testVM)
        {
            var Id2 = User.FindFirstValue("uid");
            int id = Convert.ToInt32(Id2);
            var result = await _testServic.UpdateTestAsync(Id,testVM,id);
            return Ok(result);
        }
    }
}
