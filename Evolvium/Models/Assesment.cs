using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evolvium.Presentation.Models
{
    public class Assesment
    {
        public string? AssessmentId { get; set; }
        public string ModuleId { get; set; }
        public string DegreeId { get; set; }
        public float Score { get; set; }
    }
}
