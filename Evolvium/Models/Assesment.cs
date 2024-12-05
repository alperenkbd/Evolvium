using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evolvium.Presentation.Models
{
    internal class Assesment
    {
        public Guid AssesmentId { get; set; }
        public Student? DefinedStudent { get; set; }
        public Degree? DefinedDegree { get; set; }
        public Module? DefinedModule { get; set; }
        public float Score { get; set; }
    }
}
