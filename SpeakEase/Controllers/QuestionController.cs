using BLL.Services.IServices;
using DAL.Enum;
using DAL.Models.Question;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SpeakEase.DAL.Entities;
using System.Security.Claims;

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

        #region Get last Question
        [Authorize(Roles = "Server,Admin,SuperAdmin,User")]
        [HttpGet("Get last Question")]
        public async Task<IActionResult> Get_LastQuestionAsync(int patientId)
        {
            var id = User.FindFirstValue("uid");
            var result = await _QuestionService.Get_LastQuestionAsync(patientId, id);
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
        public async Task<IActionResult> UpdateQuestion(int Id,[FromForm] QuestionVM Question)
        {
            var result = await _QuestionService.UpdateQuestionAsync(Id,Question);
            return Ok(result);
        }
        #endregion

        #region Get All Quction for Character
        [Authorize]
        [HttpGet("Get All Question For Character")]
        public async Task<IActionResult> Get_AllQuestionForCharacterAsync(Character character)
        {
            try
            {
                if (character == null) { return BadRequest("Question is Null"); }
                var result = await _QuestionService.Get_AllQuestionForCharacterAsync(character);
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }
        #endregion
    }
}
