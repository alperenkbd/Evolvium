using Evolvium.Bussines.Interfaces;
using Evolvium.Bussines.Models;
using Evolvium.Data.Interfaces;
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

        public Task AddModuleAsync(ModuleModel module)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ModuleModel>> GetAllModulesAsync()
        {
            throw new NotImplementedException();
        }

        public Task<ModuleModel> GetModuleByIdAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
