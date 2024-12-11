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
    public class AssesmentService : IAssesmentService
    {
        private readonly IAssesmentRepository _assesmentRepository;

        public AssesmentService(IAssesmentRepository assesmentRepository)
        {
            _assesmentRepository = assesmentRepository;
        }
        public async Task AddAssessmentAsync(Assesment assessment)
        {
            if (assessment == null)
                throw new ArgumentNullException(nameof(assessment), "Assessment cannot be null.");

            if (assessment.Score > 100)
                throw new ArgumentException("Maximum score for an assessment cannot exceed 100.", nameof(assessment.Score));


            var currentAssessments = await _assesmentRepository.GetByModuleIdAsync(assessment.ModuleId);
            var totalMaxScore = currentAssessments.Sum(a => a.Score) + assessment.Score;

            if (totalMaxScore > 100)
                throw new InvalidOperationException($"Total maximum score for module {assessment.ModuleId} exceeds 100.");

            assessment.AssessmentId = GenerateAssesmentID();

            await _assesmentRepository.AddAsync(assessment);
        }

        public async Task<IEnumerable<Assesment>> GetByModuleIdAsync(string moduleId)
        {
            if (string.IsNullOrWhiteSpace(moduleId))
                throw new ArgumentException("ModuleId cannot be null or empty.", nameof(moduleId));


            var assessments = await _assesmentRepository.GetByModuleIdAsync(moduleId);

            if (assessments == null || !assessments.Any())
                throw new InvalidOperationException($"No assessments found for module ID: {moduleId}");

            return assessments;
        }


        public async Task<IEnumerable<Assesment>> GetAllAssesmentsAsync()
        {
            return await _assesmentRepository.GetAllAssesmentsAsync();
        }

        public static string GenerateAssesmentID() => new Random().Next(100000, 999999).ToString();
    }
}
