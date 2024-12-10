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

        public StudentService(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public async Task<IEnumerable<StudentModel>> GetAllStudentsAsync()
        {
            var students = await _studentRepository.GetAllStudentsAsync();
            return students.Select(s => new StudentModel
            {
                Id = s.Id,
                FirstName = s.FirstName,
                LastName = s.LastName
            });
        }

        public async Task<StudentModel> GetStudentByIdAsync(int id)
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
                Degree = student.Degree,
                Year = student.Year,

            });
        }

        public static string GenerateStudentID() => $"{DateTime.Now.Year}{new Random().Next(100000, 999999)}";

    }
}
