using Evolvium.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evolvium.Data.Interfaces
{
    public interface IAssesmentRepository
    {
        Task<IEnumerable<Assesment>> GetAllAssesmentsAsync();
        Task AddAssesmentAsync(Assesment assesment);
        Task<IEnumerable<Assesment>> GetByModuleIdAsync(string moduleId);
        Task AddAsync(Assesment assessment);
        Task<IEnumerable<Assesment>> GetAssessmentsByModuleIdAsync(string moduleId);
    }
}
