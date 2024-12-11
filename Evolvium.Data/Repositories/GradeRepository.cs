using Evolvium.Data.Entities;
using Evolvium.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Evolvium.Data.Repositories
{
    public class GradeRepository : BaseRepository, IGradeRepository
    {

        public GradeRepository() : base("grades.json")
        {
            //override constructor because the json file names are different 
        }

        protected override void InitializeFile()
        {
            File.WriteAllText(_filePath, JsonSerializer.Serialize(new List<Grade>()));
        }
        public async Task<IEnumerable<Grade>> GetAllGradesAsync()
        {
            var jsonData = await File.ReadAllTextAsync(_filePath);
            return JsonSerializer.Deserialize<List<Grade>>(jsonData) ?? new List<Grade>();
        }
    }
}
