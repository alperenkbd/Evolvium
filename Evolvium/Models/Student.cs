using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evolvium.Presentation.Models
{
    public class Student
    {
        public string Id { get; set; } = string.Empty;
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Degree { get; set; }
        public int Year { get; set; } = 0;
    }
}
