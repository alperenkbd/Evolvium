using Evolvium.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evolvium.Data.Interfaces
{
    public interface IDegreeRepository
    {
        Task<IEnumerable<Degree>> GetAllDegreesAsync();
        Task AddDegreeAsync(Degree degree);
        Task<Degree> GetDegreeByIdAsync(string id);
    }
}
