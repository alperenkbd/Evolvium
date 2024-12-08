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
        public async Task<IActionResult> GetModules(int id)
        {
            var module = await _modulesService.GetModuleByIdAsync(id);
            if (module == null) return NotFound();
            return Ok(module);
        }

        [HttpPost]
        public async Task<IActionResult> AddModule([FromBody] ModuleModel module)
        {
            await _modulesService.AddModuleAsync(module);
            return CreatedAtAction(nameof(GetModules), new { id = module.Id }, module);
        }
    }
}
