using Evolvium.Bussines.Models;
using Evolvium.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Evolvium.Data.Entities.Assesment;

namespace Evolvium.Bussines.Interfaces
{
    public interface IAssesmentService
    {
        Task<IEnumerable<Assesment>> GetAllAssesmentsAsync();
        Task AddAssessmentAsync(Assesment assessment);
        Task<IEnumerable<Assesment>> GetByModuleIdAsync(string moduleId);
    }
}
