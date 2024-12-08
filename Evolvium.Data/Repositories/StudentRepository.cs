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
    public class StudentRepository : IStudentRepository
    {
        private readonly string _filePath = "JsonDB/students.json";

        public StudentRepository()
        {
            
            if (!File.Exists(_filePath))
            {
                File.WriteAllText(_filePath, JsonSerializer.Serialize(new List<Student>()));
            }
        }

        public async Task<IEnumerable<Student>> GetAllStudentsAsync()
        {
            var jsonData = await File.ReadAllTextAsync(_filePath);
            return JsonSerializer.Deserialize<List<Student>>(jsonData) ?? new List<Student>();
        }

        public async Task<Student> GetStudentByIdAsync(int id)
        {
            var students = await GetAllStudentsAsync();
            return students.FirstOrDefault(s => s.Id == id);
        }

        public async Task AddStudentAsync(Student student)
        {
            var students = (await GetAllStudentsAsync()).ToList();
            student.Id = students.Any() ? students.Max(s => s.Id) + 1 : 1; 
            students.Add(student);

            var jsonData = JsonSerializer.Serialize(students, new JsonSerializerOptions { WriteIndented = true });
            await File.WriteAllTextAsync(_filePath, jsonData);
        }

    }
}
