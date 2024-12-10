using Evolvium.Bussines.Interfaces;
using Evolvium.Bussines.Models;
using Evolvium.Data.Entities;
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
        private readonly IModuleService _moduleService;

        public DegreeService(IDegreeRepository degreeRepository, IModuleService moduleService)
        {
            _degreeRepository = degreeRepository;
            _moduleService = moduleService;
        }



        public async Task<bool> AddDegreeAsync(DegreeModel degree)
        {
            try
            {
                string _degreeid = GenerateDegreeID();
                var modules = GenerateModulesForDegree(degree.LengthOfDegree, _degreeid);

                
                foreach (var module in modules)
                {
                    await _moduleService.AddModuleAsync(module);
                }

                await _degreeRepository.AddDegreeAsync(new Data.Entities.Degree
                {
                    Id = _degreeid,
                    Name = degree.Name,
                    LengthOfDegree = degree.LengthOfDegree
                });

                return true;
            }
            catch
            {
                return false;
            }
        }

        private List<ModuleModel> GenerateModulesForDegree(int degreeYears, string degreeId)
        {
            var modules = new List<ModuleModel>();
            int totalModules = degreeYears * 6;

            for (int i = 1; i <= totalModules; i++)
            {
                modules.Add(new ModuleModel
                {
                    Id = string.Empty,
                    ModuleName = $"Module {i}",
                    DegreeId = degreeId
                });
            }

            return modules;
        }

        public async Task<IEnumerable<DegreeModel>> GetAllDegreesAsync()
        {
            var degrees = await _degreeRepository.GetAllDegreesAsync();
            return degrees.Select(s => new DegreeModel
            {
                Id = GenerateDegreeID(),
                LengthOfDegree = s.LengthOfDegree,
                Name = s.Name
            });
        }

        public static string GenerateDegreeID() => new Random().Next(100000, 999999).ToString();

    }
}
