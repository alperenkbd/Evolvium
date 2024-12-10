using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evolvium.Data.Entities
{
    public class Student
    {
        public string? Id { get; set; } = string.Empty;
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string DegreeId { get; set; }
        public string? DegreeName { get; set; }
        public int? DegreeLength { get; set; }
    }
}
