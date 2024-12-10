using Evolvium.Bussines.Interfaces;
using Evolvium.Bussines.Models;
using Evolvium.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Evolvium.Bussines.Services
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentRepository;
        private readonly IDegreeRepository _degreeRepository;

        public StudentService(IStudentRepository studentRepository, IDegreeRepository degreeRepository)
        {
            _studentRepository = studentRepository;
            _degreeRepository = degreeRepository;
        }

        public async Task<IEnumerable<StudentModel>> GetAllStudentsAsync()
        {
            var students = await _studentRepository.GetAllStudentsAsync();

            
            var degrees = (await _degreeRepository.GetAllDegreesAsync())
                .ToDictionary(d => d.Id);

            return students.Select(student => new StudentModel
            {
                Id = student.Id,
                FirstName = student.FirstName,
                LastName = student.LastName,
                DegreeId = student.DegreeId,
                DegreeName = degrees.ContainsKey(student.DegreeId) ? degrees[student.DegreeId].Name : null,
                DegreeLength = degrees.ContainsKey(student.DegreeId) ? degrees[student.DegreeId].LengthOfDegree : 0
            });
        }

        public async Task<StudentModel> GetStudentByIdAsync(string id)
        {
            var student = await _studentRepository.GetStudentByIdAsync(id);
            if (student == null) return null;

            return new StudentModel
            {
                Id = student.Id,
                FirstName = student.FirstName,
                LastName = student.LastName
            };
        }

        public async Task AddStudentAsync(StudentModel student)
        {
            await _studentRepository.AddStudentAsync(new Data.Entities.Student
            {
                Id = GenerateStudentID(),
                FirstName = student.FirstName,
                LastName = student.LastName,
                DegreeId = student.DegreeId

            });
        }

        public static string GenerateStudentID() => $"{DateTime.Now.Year}{new Random().Next(100000, 999999)}";

    }
}
