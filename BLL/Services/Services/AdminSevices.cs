using BLL.Services.IServices;
using DAL.Models.SpecialistModel;
using Microsoft.IdentityModel.Tokens;
using SpeakEase.Models;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.Services
{
    public class AdminSevices : IAdminSevices
    {
        public Task<Response<AdminUserVM>> AddAdminUserAsync(AdminUserVM model)
        {
            throw new NotImplementedException();
        }



        #region Private Methods
        //private async Task<JwtSecurityToken> CreateJwtToken(ApplicationUser user)
        //{
        //    var userClaims = await _userManager.GetClaimsAsync(user);
        //    var roles = await _userManager.GetRolesAsync(user);
        //    var roleClaims = new List<Claim>();

        //    foreach (var role in roles)
        //        roleClaims.Add(new Claim("roles", role));

        //    var claims = new[]
        //    {
        //        new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
        //        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
        //        new Claim(JwtRegisteredClaimNames.Email, user.Email),
        //        new Claim("uid", user.Id)
        //    }
        //    .Union(userClaims)
        //    .Union(roleClaims);

        //    var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwt.Key));
        //    var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);

        //    var jwtSecurityToken = new JwtSecurityToken(
        //        issuer: _jwt.Issuer,
        //        audience: _jwt.Audience,
        //        claims: claims,
        //        expires: DateTime.UtcNow.AddMinutes(_jwt.DurationInMinutes),
        //        signingCredentials: signingCredentials);

        //    return jwtSecurityToken;
        //}

        #endregion
    }
}
