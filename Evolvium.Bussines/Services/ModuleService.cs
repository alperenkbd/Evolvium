using Evolvium.Bussines.Interfaces;
using Evolvium.Bussines.Models;
using Evolvium.Data.Interfaces;
using Evolvium.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evolvium.Bussines.Services
{
    public class ModuleService : IModuleService
    {

        private readonly IModuleRepository _moduleRepository;

        public ModuleService(IModuleRepository moduleRepository)
        {
            _moduleRepository = moduleRepository;
        }

        public async Task AddModuleAsync(ModuleModel module)
        {
            await _moduleRepository.AddModuleAsync(new Data.Entities.Module
            {
                Id = GenerateModuleID(),
                DegreeId = module.DegreeId,

            });
        }

        public async Task<IEnumerable<ModuleModel>> GetAllModulesAsync()
        {
            var modules = await _moduleRepository.GetAllModulesAsync();
            return modules.Select(m => new ModuleModel
            {
                Id = m.Id,
                DegreeId= m.DegreeId,
                MaxScore = m.MaxScore,
                ModuleName = m.ModuleName
            });
        }

        public Task<ModuleModel> GetModuleByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public static string GenerateModuleID() => new Random().Next(100000, 999999).ToString();
    }
}
