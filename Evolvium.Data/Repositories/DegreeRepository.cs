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
    public class DegreeRepository : BaseRepository, IDegreeRepository
    {
        

        public DegreeRepository() : base("degrees.json")
        {
        }

        protected override void InitializeFile()
        {
            File.WriteAllText(_filePath, JsonSerializer.Serialize(new List<Degree>()));
        }

        public async Task AddDegreeAsync(Degree degree)
        {
            var degrees = (await GetAllDegreesAsync()).ToList();
            degrees.Add(degree);

            var jsonData = JsonSerializer.Serialize(degrees, new JsonSerializerOptions { WriteIndented = true });
            await File.WriteAllTextAsync(_filePath, jsonData);
        }

        public async Task<Degree> GetDegreeByIdAsync(string id)
        {
            var degrees = await GetAllDegreesAsync();
            return degrees.FirstOrDefault(s => s.Id == id.ToString());
        }

        public async Task<IEnumerable<Degree>> GetAllDegreesAsync()
        {
            var jsonData = await File.ReadAllTextAsync(_filePath);
            return JsonSerializer.Deserialize<List<Degree>>(jsonData) ?? new List<Degree>();
        }
    }
}
