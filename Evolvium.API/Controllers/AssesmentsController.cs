using Evolvium.Bussines.Interfaces;
using Evolvium.Bussines.Models;
using Evolvium.Bussines.Services;
using Evolvium.Data.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Evolvium.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssesmentsController : ControllerBase
    {
        private readonly IAssesmentService _assesmentService;

        public AssesmentsController(IAssesmentService assesmentService)
        {
            _assesmentService = assesmentService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAssesments()
        {
            var assesments = await _assesmentService.GetAllAssesmentsAsync();
            return Ok(assesments);
        }


        [HttpPost]
        public async Task<IActionResult> AddAssesment([FromBody] Assesment assesment)
        {
            await _assesmentService.AddAssessmentAsync(assesment);
            return CreatedAtAction(nameof(GetAssesments), new { id = assesment.AssessmentId }, assesment);
        }
    }
}
