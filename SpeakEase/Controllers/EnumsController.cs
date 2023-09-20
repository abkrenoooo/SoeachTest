using BLL.Helper;
using DAL.Enum;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace SpeakEase.Controllers
{
    [Authorize(Roles = "Server,Admin,SuperAdmin,User")]
    [Route("api/[controller]")]
    [ApiController]
    public class EnumsController : ControllerBase
    {
        [HttpPost("Get Character Enum")]
        [Authorize(Roles = "Server,Admin,SuperAdmin,User")]

        public async Task<IActionResult> GetCharacterEnum()
        {
            var result = Enum.GetValues(typeof(Character)).Cast<Character>().Select(x => x.GetType().GetMember(x.ToString()).First().GetCustomAttribute<DisplayAttribute>().GetName()).ToList();

            return Ok(result);
        }
        [Authorize(Roles = "Server,Admin,SuperAdmin,User")]
        [HttpPost("Get CharacterPosition Enum")]
        public async Task<IActionResult> GetCharacterPositionEnum()
        {
            var result = Enum.GetValues(typeof(CharacterPosition)).Cast<CharacterPosition>().Select(x => x.GetType().GetMember(x.ToString()).First().GetCustomAttribute<DisplayAttribute>().GetName()).ToList();

            return Ok(result);
        }
        [Authorize(Roles = "Server,Admin,SuperAdmin,User")]
        [HttpPost("Get CharacterPositionResult Enum")]
        public async Task<IActionResult> GetCharacterPositionResultEnum()
        {
            var result = Enum.GetValues(typeof(CharacterPositionResult)).Cast<CharacterPositionResult>().Select(x => x.GetType().GetMember(x.ToString()).First().GetCustomAttribute<DisplayAttribute>().GetName()).ToList();

            return Ok(result);
        }
        [Authorize(Roles = "Server,Admin,SuperAdmin,User")]
        [HttpPost("Get CharacterState Enum")]
        public async Task<IActionResult> GetCharacterStateEnum()
        {
            var result = Enum.GetValues(typeof(CharacterState)).Cast<CharacterState>().Select(x => x.GetType().GetMember(x.ToString()).First().GetCustomAttribute<DisplayAttribute>().GetName()).ToList();

            return Ok(result);
        }
        [Authorize(Roles = "Server,Admin,SuperAdmin,User")]
        [HttpPost("Get EducationState Enum")]
        public async Task<IActionResult> GetEducationStateEnum()
        {
            var result = Enum.GetValues(typeof(EducationState)).Cast<EducationState>().Select(x => x.GetType().GetMember(x.ToString()).First().GetCustomAttribute<DisplayAttribute>().GetName()).ToList();

            return Ok(result);
        }
        [Authorize(Roles = "Server,Admin,SuperAdmin,User")]
        [HttpPost("Get Gender Enum")]
        public async Task<IActionResult> GetGenderEnum()
        {
            var result = Enum.GetValues(typeof(Gender)).Cast<Gender>().Select(x => x.GetType().GetMember(x.ToString()).First().GetCustomAttribute<DisplayAttribute>().GetName()).ToList();

            return Ok(result);
        }
        
        [Authorize(Roles = "Server,Admin,SuperAdmin,User")]
        [HttpPost("Get OME Enum")]
        public async Task<IActionResult> GetOMEEnum()
        {
            var result = Enum.GetValues(typeof(OME)).Cast<OME>().Select(x => x.GetType().GetMember(x.ToString()).First().GetCustomAttribute<DisplayAttribute>().GetName()).ToList();

            return Ok(result);
        }
    }
}
