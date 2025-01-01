using HiringForm.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace HiringForm.Contexts
{
    public class HiringFormContext(DbContextOptions<HiringFormContext> options) : DbContext(options)
    {
        public DbSet<Applicant> Applicants { get; set; }
        public DbSet<Education> Educations { get; set; }
        public DbSet<WorkExperience> WorkExperiences { get; set; }
        public DbSet<Internship> Internships { get; set; }
        public DbSet<KnownLanguage> KnownLanguages { get; set; }
        public DbSet<ProgrammingLanguage> ProgrammingLanguages { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<KnownLanguage>()
                .HasOne(kl => kl.Applicant)
                .WithMany(a => a.KnownLanguages)
                .HasForeignKey(kl => kl.ApplicantId);

            modelBuilder.Entity<ProgrammingLanguage>()
                .HasOne(pl => pl.Applicant)
                .WithMany(a => a.ProgrammingLanguages)
                .HasForeignKey(pl => pl.ApplicantId);
        }


    }
}