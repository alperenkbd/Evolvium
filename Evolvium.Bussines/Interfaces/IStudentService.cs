using Evolvium.Bussines.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evolvium.Bussines.Interfaces
{
    public interface IStudentService
    {
        Task<IEnumerable<StudentModel>> GetAllStudentsAsync();
        Task<StudentModel> GetStudentByIdAsync(string id);
        Task AddStudentAsync(StudentModel student);
    }
}
