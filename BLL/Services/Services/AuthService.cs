using BlL.Helper;
using BLL.Services.IServices;
using DAL.Enum;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using SpeakEase.BLL.Helper;
using SpeakEase.DAL.Data;
using SpeakEase.DAL.Entities;
using SpeakEase.Models;
using SpeakEase.Models.AuthModel;
using SpeakEase.Models.SpecialistModel;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace BLL.Services.Services
{
    public class AuthService : IAuthService
    {
        private readonly ApplicationDbContext _db;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly JWT _jwt; 
       private readonly IHttpContextAccessor _httpContextAccessor;
        public AuthService(UserManager<ApplicationUser> UserManager, IOptions<JWT> jwt, ApplicationDbContext db , IHttpContextAccessor httpContextAccessor)
        {
            _db = db;
            _userManager = UserManager;
            _jwt = jwt.Value; 
           _httpContextAccessor = httpContextAccessor;
        }

        #region Authentication Services
        public async Task<Response<AuthModel>> LoginAsync(LoginUser login)
        {
            try
            {
                // Check if email or password true or not
                var user = await _userManager.FindByEmailAsync(login.Email);

                if (user == null || !await _userManager.CheckPasswordAsync(user, login.Password))
                    return new() { Message = "Invalid password or email" };


                // create token for the user
                var jwtSecurityToken = await CreateJwtToken(user);
                var studentRoles = await _userManager.GetRolesAsync(user);


                return new Response<AuthModel>
                {
                    Success = true,
                    ObjectData = new AuthModel()
                    {
                        Email = user.Email,
                        ExpiresOn = jwtSecurityToken.ValidTo,
                        IsAuthenticated = true,
                        Roles = studentRoles.ToList(),
                        Token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken),
                        Username = user.UserName
                    }
                };
            }
            catch (Exception ex)
            {
                return new Response<AuthModel>
                {
                    Success = false,
                    status_code = "404",
                    Message = "Not Found"
                };
            }
        }

        public async Task<Response<AuthModel>> RegisterUserAsync(SpecialistVM model)
        {
            try
            {
                if (await _userManager.FindByEmailAsync(model.Email) is not null)
                    return new Response<AuthModel> { Message = "Email is already registered!" };

                if (await _userManager.FindByNameAsync(model.Username) is not null)
                    return new Response<AuthModel> { Message = "Username is already registered!" };

                var user = new ApplicationUser
                {
                    UserName = model.Username,
                    Email = model.Email,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    SecondName = model.SecondName,
                    BirithDate = model.BirithDate,
                    Gender = model.Gender,
                    Active = false,

                };

                var result = await _userManager.CreateAsync(user, model.Password);

                if (!result.Succeeded)
                {
                    var errors = string.Empty;

                    foreach (var error in result.Errors)
                        errors += $"{error.Description},";

                    return new Response<AuthModel> { Message = errors };
                }

                await _userManager.AddToRoleAsync(user, Roles.User.ToString());
                if (model.ImageOfSpecializationCertificate is not null)
                {
                  
                    var FileVedio = UploadFileHelper.SaveFile(model.ImageOfSpecializationCertificate, "ImageOfSpecializationCertificate");
                    model.ImageOfSpecializationCertificatePath = _httpContextAccessor.HttpContext.Request.Host.Value + "/ImageOfSpecializationCertificate/" + FileVedio[0];
                }

                Specialist specialist = new Specialist()
                {
                    UserId = _userManager.FindByNameAsync(model.Username).Result.Id,
                    State = model.Status,
                    Country=model.Country,
                    City =model.City,
                    Accepted=false,
                    Hospital=model.Hospital,
                    IdNumber=model.IdNumber,
                    ImageOfSpecializationCertificate=model.ImageOfSpecializationCertificatePath,
                };

                //specialist.UserId = _userManager.FindByNameAsync(model.Username).Result.Id;
                //specialist.State = model.Status;
                await _db.Specialists.AddAsync(specialist);
                await _db.SaveChangesAsync();

                var jwtSecurityToken = await CreateJwtToken(user);


                await _userManager.UpdateAsync(user);
                var studentRoles = await _userManager.GetRolesAsync(user);
                AuthModel objectData = new AuthModel()
                {
                    Email = user.Email,
                    ExpiresOn = jwtSecurityToken.ValidTo,
                    IsAuthenticated = true,
                    Roles = studentRoles.ToList(),
                    Token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken),
                    Username = user.UserName
                };

                return new Response<AuthModel>
                {
                    Success = true,
                    ObjectData = objectData
                };
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message, ex.StackTrace);
                return new()
                {
                    Message = ex.Message
                };
            }

        }
        #endregion

        #region Private Methods
        private async Task<JwtSecurityToken> CreateJwtToken(ApplicationUser user)
        {
            var userClaims = await _userManager.GetClaimsAsync(user);
            var roles = await _userManager.GetRolesAsync(user);
            var roleClaims = new List<Claim>();

            foreach (var role in roles)
                roleClaims.Add(new Claim("roles", role));

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim("uid", user.Id)
            }
            .Union(userClaims)
            .Union(roleClaims);

            var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwt.Key));
            var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);

            var jwtSecurityToken = new JwtSecurityToken(
                issuer: _jwt.Issuer,
                audience: _jwt.Audience,
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(_jwt.DurationInMinutes),
                signingCredentials: signingCredentials);

            return jwtSecurityToken;
        }

        #endregion
    }
}
