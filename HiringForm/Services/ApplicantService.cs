using HiringForm.Models.Entities;
using HiringForm.Repositories;

namespace HiringForm.Services
{
    public interface IApplicantService
    {
        Task AddApplicantAsync(Applicant applicant);
        Task<List<Applicant>> GetApplicantsOrderedByScoreAsync();
        int CalculateScore(Applicant applicant);
    }

    public class ApplicantService : IApplicantService
    {
        private readonly IApplicantRepository _repository;

        public ApplicantService(IApplicantRepository repository)
        {
            _repository = repository;
        }

        public async Task AddApplicantAsync(Applicant applicant)
        {
            applicant.Score = CalculateScore(applicant); // Calculate score before saving
            await _repository.AddApplicantAsync(applicant);
            await _repository.SaveChangesAsync();
        }

        public async Task<List<Applicant>> GetApplicantsOrderedByScoreAsync()
        {
            return await _repository.GetApplicantsOrderedByScoreAsync();
        }

        public int CalculateScore(Applicant applicant)
        {
            int score = 0;

            // Example scoring rules
            if (applicant.KnownLanguages != null && applicant.KnownLanguages.Contains("English"))
            {
                score += 2;
            }

            if (applicant.NumberOfLanguages > 2)
            {
                score += applicant.NumberOfLanguages;
            }

            if (applicant.ProgrammingLanguages != null && applicant.ProgrammingLanguages.Count > 0)
            {
                score += applicant.ProgrammingLanguages.Count;
            }

            return score;
        }
    }
}