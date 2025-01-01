using HiringForm.Contexts;
using HiringForm.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace HiringForm.Repositories
{
    public interface IApplicantRepository
    {
        Task AddApplicantAsync(Applicant applicant);
        Task<List<Applicant>> GetApplicantsOrderedByScoreAsync();
        Task SaveChangesAsync();
    }

    public class ApplicantRepository : IApplicantRepository
    {
        private readonly HiringFormContext _context;

        public ApplicantRepository(HiringFormContext context)
        {
            _context = context;
        }

        public async Task AddApplicantAsync(Applicant applicant)
        {
            await _context.Applicants.AddAsync(applicant);
        }

        public async Task<List<Applicant>> GetApplicantsOrderedByScoreAsync()
        {
            return await _context.Applicants.OrderByDescending(a => a.Score).ToListAsync();
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}