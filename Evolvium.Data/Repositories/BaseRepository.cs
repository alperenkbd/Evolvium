using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Evolvium.Data.Repositories
{
    public abstract class BaseRepository
    {
        protected readonly string _filePath;

        protected BaseRepository(string fileName)
        {
            string projectRoot = Path.GetFullPath(
                Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\..\..\Evolvium\Evolvium.Data\JsonDB")
            );

            _filePath = Path.Combine(projectRoot, fileName);

            var directory = Path.GetDirectoryName(_filePath);
            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }

            // Ensure the file exists
            if (!File.Exists(_filePath))
            {
                InitializeFile();
            }
        }

        
        protected virtual void InitializeFile()
        {
            File.WriteAllText(_filePath, JsonSerializer.Serialize(new List<object>()));
        }
    }
}
