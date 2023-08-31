using SpeakEase.DAL.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace SpeakEase.DAL.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        #region Comment
        //protected override void OnModelCreating(ModelBuilder builder)
        //{
        //    base.OnModelCreating(builder);

        //    builder.Entity<Specialist>().HasMany(p => p.patients).WithMany(t => t.Specialists).UsingEntity<SpecialistPatient>(
        //        j => j
        //            .HasOne(pt => pt.Patient).WithMany(t => t.SpecialistPatients).HasForeignKey(pt => pt.PatientId),
        //        j => j
        //            .HasOne(pt => pt.Specialist).WithMany(t => t.SpecialistPatients).HasForeignKey(pt => pt.SpecialistId),
        //        j =>
        //        {
        //            j.Property(pt => pt.DateTime).HasDefaultValueSql("GETDATE()");
        //            j.HasKey(t => new { t.SpecialistId, t.PatientId,t.Id });
        //        }
        //        );
        //    builder.Entity<Specialist>().HasMany(p => p.Tests).WithMany(t => t.Specialists).UsingEntity<SpecialistTest>(
        //        j => j
        //            .HasOne(pt => pt.Test).WithMany(t => t.SpecialistTests).HasForeignKey(pt => pt.TestId),
        //        j => j
        //            .HasOne(pt => pt.Specialist).WithMany(t => t.SpecialistTests).HasForeignKey(pt => pt.SpecialistId),
        //        j =>
        //        {
        //            j.Property(pt => pt.DateTime).HasDefaultValueSql("GETDATE()");
        //            j.HasKey(t => new { t.SpecialistId, t.TestId, t.Id });
        //        }
        //        );
        //    builder.Entity<Test>().HasMany(p => p.patients).WithMany(t => t.Tests).UsingEntity<PatientTests>(
        //        j => j
        //            .HasOne(pt => pt.Patient).WithMany(t => t.PatientTests).HasForeignKey(pt => pt.PatientId),
        //        j => j
        //            .HasOne(pt => pt.Test).WithMany(t => t.PatientTests).HasForeignKey(pt => pt.TestId),
        //        j =>
        //        {
        //            j.Property(pt => pt.DateTime).HasDefaultValueSql("GETDATE()");
        //            j.HasKey(t => new { t.TestId, t.PatientId, t.Id });
        //        }
        //        );
        //}

        //public DbSet<Specialist> Specialists { get; set; }
        //public DbSet<Patient> patients { get; set; }
        //public DbSet<Test> Tests { get; set; }
        //public DbSet<SpecialistTest> SpecialistTests { get; set; }
        //public DbSet<SpecialistPatient> SpecialistPatients { get; set; }
        //public DbSet<PatientTests> PatientTests { get; set; }
        //public DbSet<QuctionTest> QuctionTests { get; set; }
        //public DbSet<Note> Notes { get; set; }
        //public DbSet<HistoryVistor> HistoryVistors { get; set; }
        #endregion
        public DbSet<Specialist> Specialists { get; set; }
        public DbSet<Result> Results { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<QuestionTest> QuctionTests { get; set; }
        public DbSet<Chear> Chears { get; set; }
        protected override async void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<ApplicationUser>().ToTable("Users", "security");
            builder.Entity<IdentityRole>().ToTable("Roles", "security");
            builder.Entity<IdentityUserRole<string>>().ToTable("UserRoles", "security");
            builder.Entity<IdentityUserClaim<string>>().ToTable("UserClaims", "security");
            builder.Entity<IdentityUserLogin<string>>().ToTable("UserLogins", "security");
            builder.Entity<IdentityRoleClaim<string>>().ToTable("RoleClaims", "security");
            builder.Entity<IdentityUserToken<string>>().ToTable("UserTokens", "security");
        }
    }
}
