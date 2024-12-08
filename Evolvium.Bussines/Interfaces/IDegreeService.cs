using Evolvium.Bussines.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evolvium.Bussines.Interfaces
{
    public interface IDegreeService
    {
        Task<IEnumerable<DegreeModel>> GetAllDegreesAsync();
        Task AddDegreeAsync(DegreeModel degree);
    }
}
