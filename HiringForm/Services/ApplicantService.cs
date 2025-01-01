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
            applicant.Score = CalculateScore(applicant);
            await _repository.AddApplicantAsync(applicant);
            await _repository.SaveChangesAsync();
        }

        public async Task<List<Applicant>> GetApplicantsOrderedByScoreAsync()
        {
            return await _repository.GetApplicantsOrderedByScoreAsync();
        }

        public int CalculateScore(Applicant applicant)
        {
            if (!applicant.ProgrammingLanguages.Any(x => x.Language == "Java" || x.Language == "Python"))
            {
                applicant.IsEliminated = true;
                return 0;
            }
            int score = 0;
            var rules = new List<Func<Applicant, int>>()
            {
            a => a.ProgrammingLanguages.Count(x => x.Language != null) > 3 ? 20 : 0,
            a => a.ProgrammingLanguages.Count(x => x.Language != null) == 2 ? 10 : 0,
            a => a.ProgrammingLanguages.Count(x => x.Language != null) == 1 ? 5 : 0,
            a => a.KnownLanguages.Any(x => x.Language == "İngilizce") ? 15 : 0,
            a => a.KnownLanguages.Count() > 0 ? a.KnownLanguages.Count() * 5 : 0,
            a => a.Educations.Any(x => x.Degree == "Yüksek Lisans") ? 20 : 0,
            a => a.Educations.Any(x => x.Degree == "Lisans") ? 10 : 0,
            a => a.WorkExperiences.Any(x => x.Experience >= 3) ? 25 : 0,
            a => a.WorkExperiences.Any(x => x.Experience < 3 && x.Experience > 1) ? 15 : 0,
            a => a.WorkExperiences.Any(x => x.Experience < 1 && x.Experience > 0) ? 5 : 0,
            a => a.KpssGrade > 80 ? 30 : 0,
            a => a.KpssGrade > 70 ? 15 : 5,
            a => a.EnglishLevel == "main" ? 20 : 0,
            a => a.EnglishLevel == "full-prof" ? 15 : 0,
            a => a.EnglishLevel == "prof" ? 10 : 0,
            a => a.EnglishLevel == "limited" ? 5 : 0,
            a => a.Internships.Count(x => x.CompanyName != null) >= 2 ? 10 : 0,
            a => a.Internships.Count(x => x.CompanyName != null) == 1 ? 5 : 0
            };

            foreach (var rule in rules)
            {
                score += rule(applicant);
            }

            if (score > 100)
            {
                applicant.IsCalledToInterview = true;
            }

            return score;
        }
    }
}