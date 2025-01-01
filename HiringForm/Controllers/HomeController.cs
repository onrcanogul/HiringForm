using HiringForm.Models.Entities;
using HiringForm.Services;
using Microsoft.AspNetCore.Mvc;

namespace HiringForm.Controllers
{
    public class HomeController : Controller
    {
        private readonly IApplicantService _service;

        public HomeController(IApplicantService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View();
        }

        public async Task<IActionResult> List()
        {
            return View(await _service.GetApplicantsOrderedByScoreAsync());
        }


        [HttpPost]
        public async Task<IActionResult> Create(Applicant applicant, List<string> selectedLanguages, string knownLanguagesText, List<string> programmingLanguages)
        {
            if (knownLanguagesText != null)
                selectedLanguages = selectedLanguages.Concat(knownLanguagesText.Split(",")).ToList();
            foreach (var language in selectedLanguages)
            {
                applicant.KnownLanguages.Add(new KnownLanguage() { Language = language });
            }
            foreach (var language in programmingLanguages)
            {
                applicant.ProgrammingLanguages.Add(new ProgrammingLanguage() { Language = language });
            }
            await _service.AddApplicantAsync(applicant);
            return RedirectToAction("List");
        }
    }
}