using Evolvium.Bussines.Interfaces;
using Evolvium.Bussines.Models;
using Evolvium.Data.Interfaces;
using Evolvium.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evolvium.Bussines.Services
{
    public class DegreeService : IDegreeService
    {
        private readonly IDegreeRepository _degreeRepository;

        public DegreeService(IDegreeRepository degreeRepository)
        {
            _degreeRepository = degreeRepository;
        }

        public async Task AddDegreeAsync(DegreeModel degree)
        {
            await _degreeRepository.AddDegreeAsync(new Data.Entities.Degree
            {
                Name = degree.Name,
                LengthOfDegree = degree.LengthOfDegree
            });
        }

        public async Task<IEnumerable<DegreeModel>> GetAllDegreesAsync()
        {
            var degrees = await _degreeRepository.GetAllDegreesAsync();
            return degrees.Select(s => new DegreeModel
            {
                Id = s.Id,
                LengthOfDegree = s.LengthOfDegree,
                Name = s.Name
            });
        }
    }
}
