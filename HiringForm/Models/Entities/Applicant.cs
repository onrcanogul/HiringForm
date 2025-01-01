namespace HiringForm.Models.Entities
{
    public class Applicant
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Birthplace { get; set; }
        public DateTime Birthdate { get; set; }
        public string Gender { get; set; }
        public string MaritalStatus { get; set; }

        public string Address { get; set; }
        public string City { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }

        public List<Education> Educations { get; set; } = new();
        public List<WorkExperience> WorkExperiences { get; set; } = new();
        public List<Internship> Internships { get; set; } = new();
        public List<ProgrammingLanguage> ProgrammingLanguages { get; set; } = new();
        public string? OtherProgrammingLanguages { get; set; }
        public string? Tools { get; set; }
        public int NumberOfLanguages { get; set; }
        public List<KnownLanguage> KnownLanguages { get; set; } = new();
        public string? AdditionalNotes { get; set; }
        public int Score { get; set; }
        public double KpssGrade { get; set; }
        public string? EnglishLevel { get; set; }
        public bool IsEliminated { get; set; }
        public bool IsCalledToInterview { get; set; }
    }

    public class KnownLanguage
    {
        public int Id { get; set; }
        public int ApplicantId { get; set; }
        public Applicant Applicant { get; set; }
        public string? Language { get; set; }
    }
    public class ProgrammingLanguage
    {
        public int Id { get; set; }
        public int ApplicantId { get; set; }
        public Applicant Applicant { get; set; }
        public string? Language { get; set; }
    }
}
