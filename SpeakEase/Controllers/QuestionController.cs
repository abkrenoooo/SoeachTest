using BLL.Services.IServices;
using DAL.Enum;
using DAL.Models.Question;
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
    public class QuestionController : ControllerBase
    {
        #region Depend Injection
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IQuestionService _QuestionService;

        public QuestionController(UserManager<ApplicationUser> userManager, IQuestionService QuestionService)
        {
            _userManager = userManager;
            _QuestionService = QuestionService;
        }
        #endregion

        #region Create
        [Authorize(Roles = "Server,Admin,SuperAdmin")]

        [HttpPost("Add Question")]
        public async Task<IActionResult> AddQuestion([FromForm] QuestionVM Question)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var result = await _QuestionService.CreateQuestionAsync(Question);
            return Ok(result);
        }
        #endregion

        #region Get
        [Authorize(Roles = "Server,Admin,SuperAdmin,User")]
        [HttpGet("Get Question")]
        public async Task<IActionResult> GetQuestion(int QuestionId)
        {
            var result = await _QuestionService.GetQuestionAsync(QuestionId);
            return Ok(result);
        }
        #endregion

        #region Get Secound Question
        [Authorize(Roles = "Server,Admin,SuperAdmin,User")]
        [HttpGet("Get Secound Question")]
        public async Task<IActionResult> GetSecoundQuestion(int QuestionId)
        {
            var result = await _QuestionService.GetSecoundQuestionAsync(QuestionId);
            return Ok(result);
        }
        #endregion

        #region Replace Question
        [Authorize(Roles = "Server,Admin,SuperAdmin,User")]

        [HttpGet(" Replace Question")]
        public async Task<IActionResult> GetReplaceQuestion(int QuestionId)
        {
            var result = await _QuestionService.GetReplaceQuestionAsync(QuestionId);
            return Ok(result);
        }
        #endregion

        #region Get All
        [Authorize(Roles = "Server,Admin,SuperAdmin,User")]

        [HttpGet("Get All Question")]
        public async Task<IActionResult> GetAllQuestion(int Pagging)
        {
            var result = await _QuestionService.GetAllQuestionAsync(Pagging);
            return Ok(result);
        }
        #endregion

        #region Delete
        [Authorize(Roles = "Server,Admin,SuperAdmin")]
        [HttpDelete("Delete Question")]
        public async Task<IActionResult> DeleteQuestion(int QuestionId)
        {
            var result = await _QuestionService.DeleteQuestionAsync(QuestionId);
            return Ok(result);
        }
        #endregion

        #region Updete
        [Authorize(Roles = "Server,Admin,SuperAdmin")]

        [HttpPut("Update Question")]
        public async Task<IActionResult> UpdateQuestion([FromForm] QuestionEditVM Question)
        {
            var result = await _QuestionService.UpdateQuestionAsync(Question);
            return Ok(result);
        }
        #endregion
    }
}
