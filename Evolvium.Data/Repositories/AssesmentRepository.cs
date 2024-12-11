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
    public class AssesmentRepository : BaseRepository, IAssesmentRepository
    {

        public AssesmentRepository() : base("assesments.json")
        {
            //override constructor because the json file names are different 
        }

        protected override void InitializeFile()
        {
            File.WriteAllText(_filePath, JsonSerializer.Serialize(new List<Assesment>()));
        }

        public Task AddAssesmentAsync(Assesment assesment)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Module>> GetAllModulesAsync()
        {
            var jsonData = await File.ReadAllTextAsync(_filePath);
            return JsonSerializer.Deserialize<List<Module>>(jsonData) ?? new List<Module>();
        }


        public async Task AddAsync(Assesment assessment)
        {
            var jsonData = await File.ReadAllTextAsync(_filePath);
            var assessments = JsonSerializer.Deserialize<List<Assesment>>(jsonData) ?? new List<Assesment>();

            assessments.Add(assessment);

            jsonData = JsonSerializer.Serialize(assessments, new JsonSerializerOptions { WriteIndented = true });
            await File.WriteAllTextAsync(_filePath, jsonData);
        }


        public async Task<IEnumerable<Assesment>> GetAllAssesmentsAsync()
        {
            var jsonData = await File.ReadAllTextAsync(_filePath);
            return JsonSerializer.Deserialize<List<Assesment>>(jsonData) ?? new List<Assesment>();
        }

        public async Task<IEnumerable<Assesment>> GetByModuleIdAsync(string moduleId)
        {
            var jsonData = await File.ReadAllTextAsync(_filePath);
            var assessments = JsonSerializer.Deserialize<List<Assesment>>(jsonData) ?? new List<Assesment>();

            return assessments.Where(a => a.ModuleId == moduleId);
        }

        public async Task<IEnumerable<Assesment>> GetAssessmentsByModuleIdAsync(string moduleId)
        {
            var jsonData = await File.ReadAllTextAsync(_filePath);
            var assessments = JsonSerializer.Deserialize<List<Assesment>>(jsonData) ?? new List<Assesment>();

            return assessments.Where(a => a.ModuleId == moduleId).ToList();
        }


    }
}
