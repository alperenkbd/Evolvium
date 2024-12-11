using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Evolvium.Presentation.Models
{
    public class Module
    {
        public string Id { get; set; } = string.Empty;
        public string DegreeId { get; set; }
        public string? DegreeName { get; set; }
        public string ModuleName { get; set; }
        public string MaxScore { get; set; }
    }
}
