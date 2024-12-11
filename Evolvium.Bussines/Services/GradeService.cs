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
using static Evolvium.Bussines.Models.AssesmentModel;

namespace Evolvium.Bussines.Services
{
    public class GradeService : IGradeService
    {
        private readonly IStudentRepository _studentRepository;
        private readonly IDegreeRepository _degreeRepository;
        private readonly IModuleRepository _moduleRepository;
        private readonly IAssesmentRepository _assessmentRepository;

        public GradeService(
            IStudentRepository studentRepository,
            IDegreeRepository degreeRepository,
            IModuleRepository moduleRepository,
            IAssesmentRepository assessmentRepository)
        {
            _studentRepository = studentRepository;
            _degreeRepository = degreeRepository;
            _moduleRepository = moduleRepository;
            _assessmentRepository = assessmentRepository;
        }


        public async Task<IEnumerable<GradeModel>> GetAllGradesAsync()
        {
            var students = await _studentRepository.GetAllStudentsAsync();
            var gradeModels = new List<GradeModel>();

            foreach (var student in students)
            {
                var degree = await _degreeRepository.GetDegreeByIdAsync(student.DegreeId);

                var modules = await _moduleRepository.GetModulesByDegreeIdAsync(degree.Id);

                foreach (var module in modules)
                {
                    var moduleAssessments = await _assessmentRepository.GetAssessmentsByModuleIdAsync(module.Id);

                    foreach (var assessment in moduleAssessments)
                    {
                        gradeModels.Add(new GradeModel
                        {
                            StudentId = student.Id,
                            StudentName = student.FirstName,
                            StudentLastName = student.LastName,
                            DegreeId = degree.Id,
                            DegreeName = degree.Name,
                            ModuleId = module.Id,
                            ModuleName = module.ModuleName,
                            AssesmentId = assessment.AssessmentId,
                            MaxGrade = assessment.Score
                        });
                    }
                }
            }

            return gradeModels;
        }

    }
}
