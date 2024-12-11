using Evolvium.Bussines.Interfaces;
using Evolvium.Bussines.Models;
using Evolvium.Data.Entities;
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
        private readonly IDegreeRepository _degreeRepository;

        public ModuleService(IModuleRepository moduleRepository, IDegreeRepository degreeRepository)
        {
            _moduleRepository = moduleRepository;
            _degreeRepository = degreeRepository;
        }



        public async Task AddModuleAsync(ModuleModel module)
        {
            await _moduleRepository.AddModuleAsync(new Data.Entities.Module
            {
                Id = GenerateModuleID(),
                DegreeId = module.DegreeId,

            });
        }

        public async Task<IEnumerable<Module>> GetModulesByDegreeIdAsync(string degreeId)
        {
            var modules = await _moduleRepository.GetAllModulesAsync();

            return modules.Where(m => m.DegreeId == degreeId);
        }


        public async Task<ModuleModel?> UpdateModuleByIdAsync(string id, ModuleModel updatedModule)
        {
            
            var existingModuleEntity = await GetModuleByIdAsync(id);
            if (existingModuleEntity == null)
            {
                return null; 
            }

            existingModuleEntity.ModuleName = updatedModule.ModuleName;
            existingModuleEntity.MaxScore = updatedModule.MaxScore;
            existingModuleEntity.DegreeId = updatedModule.DegreeId;

            
            await _moduleRepository.UpdateModuleAsync(existingModuleEntity);

            return new ModuleModel
            {
                Id = existingModuleEntity.Id,
                DegreeId = existingModuleEntity.DegreeId,
                DegreeName = updatedModule.DegreeName, 
                MaxScore = existingModuleEntity.MaxScore,
                ModuleName = existingModuleEntity.ModuleName
            };
        }



        public async Task<IEnumerable<ModuleModel>> GetAllModulesAsync()
        {
            var modules = await _moduleRepository.GetAllModulesAsync();

            var degrees = (await _degreeRepository.GetAllDegreesAsync())
                .ToDictionary(d => d.Id);

            return modules.Select(m => new ModuleModel
            {
                Id = m.Id,
                DegreeId= m.DegreeId,
                DegreeName = degrees.ContainsKey(m.DegreeId) ? degrees[m.DegreeId].Name : null,
                MaxScore = m.MaxScore,
                ModuleName = m.ModuleName
            });
        }

        public async Task<Module?> GetModuleByIdAsync(string id)
        {
            var moduleEntity = await _moduleRepository.GetModuleByIdAsync(int.Parse(id));
            if (moduleEntity == null)
            {
                return null; 
            }

            var degree = await _degreeRepository.GetDegreeByIdAsync(moduleEntity.DegreeId);

            
            return new Module
            {
                Id = moduleEntity.Id,
                DegreeId = moduleEntity.DegreeId,
                DegreeName = degree?.Name, 
                MaxScore = moduleEntity.MaxScore,
                ModuleName = moduleEntity.ModuleName
            };
        }


        public static string GenerateModuleID() => new Random().Next(100000, 999999).ToString();
    }
}
