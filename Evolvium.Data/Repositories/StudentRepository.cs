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
    public class StudentRepository : BaseRepository ,IStudentRepository
    {
        

        public StudentRepository() : base("students.json")
        {
            //override constructor because the json file names are different 
        }

        protected override void InitializeFile()
        {
            File.WriteAllText(_filePath, JsonSerializer.Serialize(new List<Student>()));
        }

        public async Task<IEnumerable<Student>> GetAllStudentsAsync()
        {
            var jsonData = await File.ReadAllTextAsync(_filePath);
            return JsonSerializer.Deserialize<List<Student>>(jsonData) ?? new List<Student>();
        }

        public async Task<Student> GetStudentByIdAsync(string id)
        {
            var students = await GetAllStudentsAsync();
            return students.FirstOrDefault(s => s.Id == id.ToString());
        }

        public async Task AddStudentAsync(Student student)
        {
            var students = (await GetAllStudentsAsync()).ToList();
            students.Add(student);

            var jsonData = JsonSerializer.Serialize(students, new JsonSerializerOptions { WriteIndented = true });
            await File.WriteAllTextAsync(_filePath, jsonData);
        }

    }
}
