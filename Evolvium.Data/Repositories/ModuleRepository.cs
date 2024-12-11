using Evolvium.Data.Entities;
using Evolvium.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Evolvium.Data.Repositories
{
    public class ModuleRepository : BaseRepository, IModuleRepository
    {
        

        public ModuleRepository() : base("modules.json")
        {
            //override constructor because the json file names are different 
        }

        protected override void InitializeFile()
        {
            File.WriteAllText(_filePath, JsonSerializer.Serialize(new List<Module>()));
        }

        public async Task AddModuleAsync(Module module)
        {
            var modules = (await GetAllModulesAsync()).ToList();
            modules.Add(module);

            var jsonData = JsonSerializer.Serialize(modules, new JsonSerializerOptions { WriteIndented = true });
            await File.WriteAllTextAsync(_filePath, jsonData);
        }

        public async Task<IEnumerable<Module>> GetAllModulesAsync()
        {
            var jsonData = await File.ReadAllTextAsync(_filePath);
            return JsonSerializer.Deserialize<List<Module>>(jsonData) ?? new List<Module>();
        }

        public async Task UpdateModuleAsync(Module updatedModule)
        {
            var modules = (await GetAllModulesAsync()).ToList();

            var existingModule = modules.FirstOrDefault(m => m.Id == updatedModule.Id);

            if (existingModule == null)
            {
                throw new Exception($"Module with ID {updatedModule.Id} not found.");
            }

            existingModule.ModuleName = updatedModule.ModuleName;
            existingModule.MaxScore = updatedModule.MaxScore;
            existingModule.DegreeId = updatedModule.DegreeId;

            var jsonData = JsonSerializer.Serialize(modules, new JsonSerializerOptions { WriteIndented = true });
            await File.WriteAllTextAsync(_filePath, jsonData);
        }


        public async Task<Module> GetModuleByIdAsync(int id)
        {
            var modules = await GetAllModulesAsync();
            return modules.FirstOrDefault(s => s.Id == id.ToString());
        }
    }
}
