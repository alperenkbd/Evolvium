using Evolvium.Bussines.Interfaces;
using Evolvium.Bussines.Models;
using Evolvium.Bussines.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Evolvium.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ModulesController : ControllerBase
    {
        private readonly IModuleService _modulesService;

        public ModulesController(IModuleService modulesService)
        {
            _modulesService = modulesService;
        }

        [HttpGet]
        public async Task<IActionResult> GetModules()
        {
            var modules = await _modulesService.GetAllModulesAsync();
            return Ok(modules);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetModules(string id)
        {
            var module = await _modulesService.GetModuleByIdAsync(id);
            if (module == null) return NotFound();
            return Ok(module);
        }

        [HttpGet("byDegree/{degreeId}")]
        public async Task<IActionResult> GetModulesByDegreeId(string degreeId)
        {
            var modules = await _modulesService.GetModulesByDegreeIdAsync(degreeId);
            if (modules == null || !modules.Any()) return NotFound("No modules found for the given degree ID.");
            return Ok(modules);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateModule(string id, [FromBody] ModuleModel updatedModule)
        {
            if (id != updatedModule.Id)
                return BadRequest("ID mismatch between route and body.");
            

            var result = await _modulesService.UpdateModuleByIdAsync(id, updatedModule);

            if (result == null)
                return NotFound($"Module with ID {id} not found.");

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> AddModule([FromBody] ModuleModel module)
        {
            await _modulesService.AddModuleAsync(module);
            return CreatedAtAction(nameof(GetModules), new { id = module.Id }, module);
        }
    }
}
