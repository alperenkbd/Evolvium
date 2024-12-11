using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evolvium.Presentation.Models
{
    public class Grades
    {
        public string? GradeId { get; set; }
        public string? StudentId { get; set; }
        public string? StudentName { get; set; }
        public string? StudentLastName { get; set; }
        public string? DegreeId { get; set; }
        public string? DegreeName { get; set; }
        public string? ModuleId { get; set; }
        public string? ModuleName { get; set; }

        public string? AssesmentId { get; set; }
        public float? MaxGrade { get; set; }
        public float StudentGrade { get; set; }
    }
}
