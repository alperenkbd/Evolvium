using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evolvium.Data.Entities
{
    public class Module
    {
        public int Id { get; set; }
        public string Number { get; set; }
        public string ModuleName { get; set; }
        public string DegreeName { get; set; }
        public string MaxScore { get; set; }
    }
}
