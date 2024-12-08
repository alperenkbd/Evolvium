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
    public class DegreeRepository : IDegreeRepository
    {
        private readonly string _filePath = "JsonDB/degrees.json";

        public DegreeRepository()
        {

            if (!File.Exists(_filePath))
            {
                File.WriteAllText(_filePath, JsonSerializer.Serialize(new List<Degree>()));
            }
        }

        public async Task AddDegreeAsync(Degree degree)
        {
            var degrees = (await GetAllDegreesAsync()).ToList();
            degree.Id = degrees.Any() ? degrees.Max(s => s.Id) + 1 : 1;
            degrees.Add(degree);

            var jsonData = JsonSerializer.Serialize(degrees, new JsonSerializerOptions { WriteIndented = true });
            await File.WriteAllTextAsync(_filePath, jsonData);
        }

        public async Task<IEnumerable<Degree>> GetAllDegreesAsync()
        {
            var jsonData = await File.ReadAllTextAsync(_filePath);
            return JsonSerializer.Deserialize<List<Degree>>(jsonData) ?? new List<Degree>();
        }
    }
}
