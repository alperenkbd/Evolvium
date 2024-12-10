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
        private readonly string _filePath;

        public DegreeRepository()
        {

            string _projectRoot = Path.GetFullPath
                (Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\..\..\Evolvium\Evolvium.Data\JsonDB"));
            _filePath = Path.Combine(_projectRoot, "degrees.json");

            var directory = Path.GetDirectoryName(_filePath);
            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }

            // Ensure the file exists
            if (!File.Exists(_filePath))
            {
                File.WriteAllText(_filePath, JsonSerializer.Serialize(new List<Student>()));
            }
        }

        public async Task AddDegreeAsync(Degree degree)
        {
            var degrees = (await GetAllDegreesAsync()).ToList();
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
