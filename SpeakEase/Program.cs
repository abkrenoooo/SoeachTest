
using SpeakEase.DAL.Data;
using SpeakEase.DAL.Entities;
using SpeakEase.BLL.Helper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;
using BLL.Seeds;
using BLL.Services.IServices;
using BLL.Services.Services;
using DAL.Repository.IRepository;
using DAL.Repository.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
using BLL.Filters;
using System.Security.Claims;

var builder = WebApplication.CreateBuilder(args);

#region Comment
//var host =builder.Build();

//using var scope = host.Services.CreateScope();


//var services = scope.ServiceProvider;
//var loggerFactory = services.GetRequiredService<ILoggerProvider>();
//var logger = loggerFactory.CreateLogger("app");

//try
//{
//    var userManager = services.GetRequiredService<UserManager<ApplicationUser>>();
//    var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();

//    await DefaultRoles.SeedAsync(roleManager);
//    await DefaultUsers.SeedServerAsync(userManager, roleManager);
//    await DefaultUsers.SeedSuperAdminUserAsync(userManager, roleManager);
//    await DefaultUsers.SeedAdminUserAsync(userManager, roleManager);

//    logger.LogInformation("Data seeded");
//    logger.LogInformation("Application Started");
//}
//catch (System.Exception ex)
//{
//    logger.LogWarning(ex, "An error occurred while seeding data");
//}
#endregion

// database and Identity
builder.Services.AddDbContext<ApplicationDbContext>(option =>
{
    option.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});
builder.Services.AddIdentity<ApplicationUser, IdentityRole>().AddEntityFrameworkStores<ApplicationDbContext>();

builder.Services.AddSingleton<IAuthorizationPolicyProvider, PermissionPolicyProvider>();
builder.Services.AddScoped<IAuthorizationHandler, PermissionAuthorizationHandler>();

builder.Services.AddAuthorization(options =>
{

    options.AddPolicy("Admin",
        authBuilder =>
        {
            authBuilder.RequireRole("Admin,Server,SuperAdmin");
        });

});
//JWT
builder.Services.Configure<JWT>(builder.Configuration.GetSection("JWT"));
//Services
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IAdminSevices, AdminSevices>();
builder.Services.AddScoped<IPatientService, PatientService>();
builder.Services.AddScoped<ISpecialistServices, SpecialistServices>();
builder.Services.AddScoped<IQuestionService, QuestionService>();
builder.Services.AddScoped<IResultServices, ResultServices>();

//Repo
builder.Services.AddScoped<IPatientRepo, PatientRepo>();
builder.Services.AddScoped<IAdminRepo, AdminRepo>();
builder.Services.AddScoped<ISpecialistRepo, SpecialistRepo>();
builder.Services.AddScoped<IQuestionRepo, QuestionRepo>();
builder.Services.AddScoped<IResultRepo, ResultRepo>();

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
})
    .AddJwtBearer(o =>
    {
        o.RequireHttpsMetadata = false;
        o.SaveToken = false;
        o.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidIssuer = builder.Configuration["JWT:Issuer"],
            ValidAudience = builder.Configuration["JWT:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWT:Key"])),
            ClockSkew = TimeSpan.Zero
        };
    });

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "SpeakEase", Version = "v1" });

    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.Http,
        BearerFormat = "JWT",
        Scheme = "bearer"
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement
        {
            {
                new OpenApiSecurityScheme
                {
                    Reference = new OpenApiReference
                    {
                        Type = ReferenceType.SecurityScheme,
                        Id = "Bearer"
                    }
                },
                new string[] {}
            }
        }
    );
});

builder.WebHost.UseContentRoot(Directory.GetCurrentDirectory());

var app = builder.Build();
using var scope = app.Services.CreateScope();


var services = scope.ServiceProvider;
var loggerFactory = services.GetRequiredService<ILoggerProvider>();

try
{
    var userManager = services.GetRequiredService<UserManager<ApplicationUser>>();
    var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();

    await DefaultRoles.SeedAsync(roleManager);
    await DefaultUsers.SeedServerAsync(userManager, roleManager);
    await DefaultUsers.SeedSuperAdminUserAsync(userManager, roleManager);
    await DefaultUsers.SeedAdminUserAsync(userManager, roleManager);
    await DefaultUsers.SeedSpetilestClaims(userManager, roleManager);

}
catch (System.Exception ex)
{

}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "SpeakEase v1");
});

app.UseHttpsRedirection();
app.UseCors(c => c.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();


app.Run();
