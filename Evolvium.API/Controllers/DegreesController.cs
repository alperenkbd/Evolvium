using Evolvium.Bussines.Interfaces;
using Evolvium.Bussines.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Evolvium.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DegreesController : ControllerBase
    {
        private readonly IDegreeService _degreeServices;

        public DegreesController(IDegreeService degreesServices)
        {
            _degreeServices = degreesServices;
        }

        [HttpGet]
        public async Task<IActionResult> GetDegrees()
        {
            var degrees = await _degreeServices.GetAllDegreesAsync();
            return Ok(degrees);
        }


        [HttpPost]
        public async Task<IActionResult> AddStudent([FromBody] DegreeModel degree)
        {
            await _degreeServices.AddDegreeAsync(degree);
            return CreatedAtAction(nameof(GetDegrees), new { id = degree.Id }, degree);
        }
    }
}
