using HiringForm.Models.Entities;
using HiringForm.Services;
using Microsoft.AspNetCore.Mvc;

namespace HiringForm.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ApplicantController : ControllerBase
    {
        private readonly IApplicantService _service;

        public ApplicantController(IApplicantService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> SubmitApplicant([FromBody] Applicant applicant)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _service.AddApplicantAsync(applicant);
            return Ok(new { Message = "Applicant data saved successfully." });
        }

        [HttpGet("ranked")]
        public async Task<IActionResult> GetRankedApplicants()
        {
            var applicants = await _service.GetApplicantsOrderedByScoreAsync();
            return Ok(applicants);
        }
    }