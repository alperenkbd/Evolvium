using Evolvium.Bussines.Models;
using Evolvium.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evolvium.Bussines.Interfaces
{
    public interface IModuleService
    {
        Task<IEnumerable<ModuleModel>> GetAllModulesAsync();
        Task<Module> GetModuleByIdAsync(string id);
        Task<ModuleModel?> UpdateModuleByIdAsync(string id, ModuleModel updatedModule);
        Task<IEnumerable<Module>> GetModulesByDegreeIdAsync(string degreeId);
        Task AddModuleAsync(ModuleModel module);
    }
}
