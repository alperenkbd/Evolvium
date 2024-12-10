using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evolvium.Bussines.Models
{
    public class StudentModel
    {
        public string? Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string DegreeId { get; set; }
        public string? DegreeName { get; set; }
        public int? DegreeLength { get; set; }
    }
}
