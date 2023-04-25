using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

namespace WorkMVVM
{
    public class JsonFileService : IFileService
    {
        public List<T> Open<T>(string filename)
        {
            string myJson = File.ReadAllText(filename);
            List<T>? accounts = JsonConvert.DeserializeObject<List<T>>(myJson);
            return accounts;
        }

        public void Save<T>(string filename, List<T> list)
        {
            File.WriteAllText(filename, JsonConvert.SerializeObject(list, Formatting.Indented));
        }
    }
}
