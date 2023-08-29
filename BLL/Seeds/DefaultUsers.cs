using DAL.Enum;
using Microsoft.AspNetCore.Identity;
using SpeakEase.DAL.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace BLL.Seeds
{
    public static class DefaultUsers
    {
        public static async Task SeedHRrAsync(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManger)
        {
            var defaultUser = new ApplicationUser
            {
                UserName = "Server",
                FirstName = "Server",
                SecondName= "Server",
                LastName= "Server",
                Email = "Server@domain.com",
                EmailConfirmed = true,
                Active = true
            };

            var user = await userManager.FindByEmailAsync(defaultUser.Email);

            if (user == null)
            {
                await userManager.CreateAsync(defaultUser, "Server@123");
                await userManager.AddToRoleAsync(defaultUser, Roles.Server.ToString());
            }
            await roleManger.SeeDLLlClaimsForHR();
        }

        public static async Task SeedSuperAdminUserAsync(UserManager<ApplicationUser> userManager)
        {
            var defaultUser = new ApplicationUser
            {
                UserName = "SuperAdmin",
                FirstName = "SuperAdmin",
                SecondName = "SuperAdmin",
                LastName = "SuperAdmin",
                Email = "SuperAdmin@domain.com",
                EmailConfirmed = true,
                Active = true
            };

            var user = await userManager.FindByEmailAsync(defaultUser.Email);

            if (user == null)
            {
                await userManager.CreateAsync(defaultUser, "SuperAdmin@123");
                await userManager.AddToRoleAsync(defaultUser,Roles.SuperAdmin.ToString() );
            }
            
        }
        public static async Task SeedAdminUserAsync(UserManager<ApplicationUser> userManager)
        {
            var defaultUser = new ApplicationUser
            {
                UserName = "Admin",
                FirstName = "Admin",
                SecondName = "Admin",
                LastName = "Admin",
                Email = "Admin@domain.com",
                EmailConfirmed = true,
                Active = true
            };

            var user = await userManager.FindByEmailAsync(defaultUser.Email);

            if (user == null)
            {
                await userManager.CreateAsync(defaultUser, "Admin@123");
                await userManager.AddToRoleAsync(defaultUser,Roles.Admin.ToString() );
            }
            
        }

        private static async Task SeeDLLlClaimsForHR(this RoleManager<IdentityRole> roleManager)
        {
            var adminRole = await roleManager.FindByNameAsync(Roles.Server.ToString());
            await roleManager.AdDLLlPermissionClaims(adminRole);
        }
        public static async Task AdDLLlPermissionClaims(this RoleManager<IdentityRole> roleManager, IdentityRole role)
        {
            var allClaims = await roleManager.GetClaimsAsync(role);
            var allPermissions = Permissions.GenerateAllPermissions();

            foreach (var permission in allPermissions)
            {
                if (!allClaims.Any(c => c.Type == "Permission" && c.Value == permission))
                    await roleManager.AddClaimAsync(role, new Claim("Permission", permission));
            }
        }
        
    }
}