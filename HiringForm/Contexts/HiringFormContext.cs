using HiringForm.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace HiringForm.Contexts
{
    public class HiringFormContext : DbContext
    {
        public DbSet<Applicant> Applicants { get; set; }
        public DbSet<Education> Educations { get; set; }
        public DbSet<WorkExperience> WorkExperiences { get; set; }
        public DbSet<Internship> Internships { get; set; }

        public HiringFormContext(DbContextOptions<HiringFormContext> options) : base(options)
        {
        }
    }
}