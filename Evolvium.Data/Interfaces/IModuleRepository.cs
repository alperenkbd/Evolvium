using Evolvium.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evolvium.Data.Interfaces
{
    public interface IModuleRepository
    {
        Task<IEnumerable<Module>> GetAllModulesAsync();
        Task<Module> GetModuleByIdAsync(int id);
        Task AddModuleAsync(Module module);
    }
}
