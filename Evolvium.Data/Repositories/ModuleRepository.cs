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
    public class ModuleRepository : IModuleRepository
    {
        private readonly string _filePath = "JsonDB/modules.json";

        public ModuleRepository()
        {

            if (!File.Exists(_filePath))
            {
                File.WriteAllText(_filePath, JsonSerializer.Serialize(new List<Module>()));
            }
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

        public async Task<Module> GetModuleByIdAsync(int id)
        {
            var students = await GetAllModulesAsync();
            return students.FirstOrDefault(s => s.Id == id);
        }
    }
}
